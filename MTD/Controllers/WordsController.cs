using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTD.Models;
using MTD.Helpers;
using MTD.Services;
using System.Web.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

namespace MTD.Controllers
{
    public class WordsController : BaseController
    {
        /// <summary>
        /// Khởi tạo service dùng cho cả chương trình.
        /// </summary>
        WordsService _service = new WordsService();

        /// <summary>
        /// Trang chủ
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(WordsCondition condition)
        {
            // Lấy danh sách từ vựng theo điều kiện tìm kiếm.
            condition.ListWordSuggest = _service.List(condition);

            // Lấy danh sách loại từ điển.
            List<SelectListItem> listDictType = _service.ListDictType();
            listDictType.Insert(0, new SelectListItem(){ Text="Chọn loại từ điển", Value="0"});
            ViewBag.ListDictType = listDictType;

            int userId = 0;
            int.TryParse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID), out userId);

            // Lấy thông tin chi tiết của từ vựng
            WordsModel model = new WordsModel();
            if(condition.Id>0){
                model = _service.GetById(condition.Id);

                // Cập nhật vào bảng lịch sử tìm kiếm.
                if (userId > 0)
                {
                    _service.UpdateWordHistory(condition.Id, userId);
                }
            }
            ViewBag.WordsModel = model;

            // Lấy danh sách lịch sử tìm kiếm.
            List<SelectListItem> listWordHistory = new List<SelectListItem>();
            if(userId>0)
            {
                listWordHistory = _service.ListWordHistory(userId);
            }
            ViewBag.ListWordHistory = listWordHistory;

            TempData["TabId"] = condition.DictType;

            return View(condition);
        }
        
        /// <summary>
        /// Danh sách từ vựng
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List(WordsCondition condition)
        {
            WordsModel model = new WordsModel();
            model.ListWord = new List<WordsModel>();
            // Kiểm tra quyền được vào xem danh sách này.
            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }
            // Hiển thị danh sách.
            int totalRecord = 0;
            model.ListWord = _service.List(condition, out totalRecord);
            model.condition = condition;

            Paging(condition.page, condition.pageSize, totalRecord);
            return View(model);
        }

        /// <summary>
        /// Màn hình cập nhật từ vựng
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(int Id)
        {
            WordsModel model = new WordsModel();

            // Lay danh sach cac loai tu dien
            model.ListDictType = new List<SelectListItem>();

            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }

            if (Id > 0)
            {
                model = _service.GetById(Id);
            }
            model.ListDictType = _service.ListDictType();

            return View(model);
        }

        /// <summary>
        /// Cập nhật từ vựng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(WordsModel model)
        {
            // Lay danh sach cac loai tu dien
            model.ListDictType = _service.ListDictType();

            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }

            if (ModelState.IsValid)
            {
                // Người cập nhật
                model.Update_By = int.Parse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID).ToString());
                int result = _service.Save(model);
                if (result > 0)
                {
                    if (model.Id > 0)
                    {
                        model.Message = Configs.SUCCESS_UPDATE;
                    }
                    else
                    {
                        model.Message = Configs.SUCCESS_INSERT;
                    }
                    model.Code = result;
                    model.Result = true;
                    model.Redirect = Url.Action("List","Words");
                    SetTempData(model.Message,model.Redirect);
                }
                else
                {
                    model.Message = Configs.ERROR_PROCESS;
                    model.Code = (int)EnumError.UPDATE_ERROR;
                    model.Result = false;
                    SetTempData(model.Message);
                }
                return View(model);
            }
            return View(model);
        }

        /// <summary>
        /// Xóa từ vựng
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult Delete(int Id)
        {
            if (!IsAdmin())
            {
                return Json(-1);
            }
            int updateBy = int.Parse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID).ToString());

            int result = _service.Delete(Id, updateBy);
            return Json(result);
        }

        /// <summary>
        /// Cập nhật trạng thái từ vựng
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public JsonResult UpdateState(int Id, int state)
        {
            if (!IsAdmin())
            {
                return Json(-1);
            }
            int updateBy = int.Parse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID).ToString());

            int result = _service.UpdateState(Id, state, updateBy);
            return Json(result);
        }

        /// <summary>
        /// Download file mẫu.
        /// Lấy toàn bộ dữ liệu hiện có của chương trình đưa vào file mẫu này.
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadTemplate()
        {
            string fileName = WebConfigurationManager.AppSettings["DictionaryTemplate"];
            string url = string.Format(Configs.URL_PHYSICAL_TEMPLATE, "DictionaryTemp.xlsx");
            byte[] fileBytes = System.IO.File.ReadAllBytes(url);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        /// <summary>
        /// Trang upload file từ vựng.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExcelUpload()
        {
            return View();
        }

        /// <summary>
        /// Xử lý upload từ vựng
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExcelUpload(HttpPostedFileBase file)
        {
            // Tạo danh sách từ mới.
            List<WordsModel> listWord = new List<WordsModel>();
            WordsModel word = new WordsModel();

            // Biến lưu kết quả trả về
            int result = 0;
            if (file != null && file.ContentLength > 0)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook workBook;
                Excel.Worksheet workSheet;
                // Bước 1: Lưu file vào server.
                string fileLocation = Server.MapPath("~/Content/Uploads/" + file.FileName);
                if (!System.IO.File.Exists(fileLocation))
                {
                    file.SaveAs(fileLocation);
                }

                // Bước 2: Đọc file.
                workBook = app.Workbooks.Open(fileLocation);
                workSheet = workBook.ActiveSheet;
                Excel.Range range = workSheet.UsedRange;

                // Duyệt toàn bộ dòng từ dòng 2.
                int chkRow = 2;
                try
                {
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        word = new WordsModel();
                        word.Dict_Type = (int)range.Cells[row, 1].Value; // Kiểu từ điển
                        word.Key = range.Cells[row, 2].Value; // Từ vựng
                        word.Value = range.Cells[row, 3].Value; // Nghĩa của từ
                        word.Update_By = int.Parse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID).ToString());
                        listWord.Add(word);
                        chkRow++;
                    }

                }
                catch
                {
                    word.Message = string.Format(Configs.ERROR_FORMAT_FILE, chkRow);
                    word.Code = (int)EnumError.UPDATE_ERROR;
                    word.Result = false;
                    SetTempData(word.Message);
                    return View();
                }

                // Nếu có yêu cầu xóa toàn bộ dữ liệu cũ thì xóa.
                var deleteOld = Request.Form.Get("deleteOld");
                if (deleteOld!=null && deleteOld == "on")
                {
                    result = _service.DeleteAll();
                }

                // Cập nhật từ vựng vào CSDL.
                result = _service.InsertFromExcel(listWord);

                workBook.Close(false, null, null);
                app.Quit();

                releaseObject(workSheet);
                releaseObject(workBook);
                releaseObject(app);

                if (result > 0)
                {
                    word.Message = Configs.SUCCESS_UPDATE;
                    word.Code = result;
                    word.Result = true;
                    word.Redirect = Url.Action("List", "Words");
                    SetTempData(word.Message, word.Redirect);
                }
                else
                {
                    word.Message = Configs.ERROR_PROCESS;
                    word.Code = (int)EnumError.UPDATE_ERROR;
                    word.Result = false;
                    SetTempData(word.Message);
                }

                // Sau khi đọc file xong thì xóa file đã upload đi.
                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }
            }
            else
            {
                word.Message = Configs.ERROR_NOT_CHOICE_FILE;
                word.Code = (int)EnumError.UPDATE_ERROR;
                word.Result = false;
                SetTempData(word.Message);
            }
            
            return View();
        }

        /// <summary>
        /// Xóa những đối tượng không còn dùng nữa.
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

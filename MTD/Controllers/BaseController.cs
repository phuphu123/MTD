using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTD.Helpers;
using MTD.DAL;
using MTD.Models;
using MTD.Services;

namespace MTD.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        // Phân trang.
        public void Paging(int page, int pageSize, int totalRecord)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            ViewBag.MaxPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            ViewBag.PageShow = 5;
            ViewBag.PagePreview = 2;
            ViewBag.TotalRecord = totalRecord;
        }

        /// <summary> Kiểm tra xem tài khoản có phải là Admin hay không.
        /// </summary>
        /// <returns></returns>
        public bool IsAdmin()
        {
            int accId = 0; // AccountID
            int.TryParse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID), out accId);
            try
            {
                // Nếu tài khoản đã là Admin thì cần kiểm tra thêm xem quyền đó còn được hoạt động hay không.
                if (CookieHelper.Get(Configs.COOKIES_ADMIN) == "1")
                {
                    AccountService service = new AccountService();
                    return service.IsAdmin(accId);
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>Lấy thông báo lỗi.
        /// </summary>
        /// <param name="errorKey"></param>
        /// <returns></returns>
        public string GetErrorMessage(int errorKey)
        {
            string result = "";
            switch (errorKey)
            {
                case -1:

                    break;

                case -404:
                    result = Configs.ERROR_NOT_FOUND_ACCOUNT;
                    break;
                default:
                    result = Configs.ERROR_PROCESS;
                    break;
            }
            return result;
        }

        /// <summary>Set template data sử dụng cho toàn web.
        /// </summary>
        /// <param name="message"></param>
        public void SetTempData(string message)
        {
            TempData[Configs.TEMP_MESSAGE] = message;
            TempData[Configs.TEMP_REDIRECT] = "";
        }

        /// <summary> Set template data sử dụng cho toàn web.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="redirect"></param>
        public void SetTempData(string message, string redirect)
        {
            TempData[Configs.TEMP_MESSAGE] = message;
            TempData[Configs.TEMP_REDIRECT] = redirect;
        }

        /// <summary>
        /// Xử lý chuyển tới trang chủ khi không được phép truy cập.
        /// </summary>
        public void SetRedirectNotAllow()
        {
            TempData[Configs.TEMP_MESSAGE] = Configs.ALERT_NOT_ALLOW;
            TempData[Configs.TEMP_REDIRECT] = Url.Action("Index", "Words");
        }

        public void InitAccount(AccountModel model, int dayExpires = 1)
        {
            string isAdmin = model.RoleId == 777 ? "1" : "0";
            
            CookieHelper.Set(Configs.COOKIES_USERNAME, model.UserName, dayExpires);
            CookieHelper.Set(Configs.COOKIES_ADMIN, isAdmin, dayExpires);
            CookieHelper.Set(Configs.COOKIES_ROLE_ID, model.RoleId.ToString(), dayExpires);
            CookieHelper.Set(Configs.COOKIES_ACCOUNT_ID, model.Id.ToString(), dayExpires);
        }

        public void RemoveAccount()
        {
            CookieHelper.Remove(Configs.COOKIES_USERNAME);
            CookieHelper.Remove(Configs.COOKIES_ACCOUNT_ID);
            CookieHelper.Remove(Configs.COOKIES_ADMIN);
            CookieHelper.Remove(Configs.COOKIES_ROLE_ID);
        }

        public ActionResult BoxSidebar()
        {
            ViewBag.ListDictTypeGlobal = HttpContext.Application["LIST_DICT_TYPE"];
            return PartialView("_BoxSidebar");
        }

        /// <summary>
        /// Hàm lấy danh sách place con theo id cha, trả về 1 chuỗi JSon.
        /// </summary>
        /// <param name="parentId">ID City</param>
        /// <returns>Json</returns>
        [HttpPost]
        public JsonResult ListPlaceJson(int parentId)
        {
            PlaceService placeService = new PlaceService();
            List<SelectListItem> lstEntity = placeService.ListItem(parentId);
            lstEntity.Insert(0, new SelectListItem { Value = "0", Text = "" });
            return Json(lstEntity);
        }
    }
}

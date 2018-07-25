using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTD.DAL;
using MTD.Models;
using MTD.Helpers;
using System.Web.Mvc;

namespace MTD.Services
{
    public class WordsService: BaseService
    {
        public WordsService() : base() { }

        /// <summary>
        /// Lấy danh sách từ vựng theo các điều kiện tìm kiếm.
        /// </summary>
        /// <param name="condition">các điều kiện tìm kiếm</param>
        /// <param name="totalRecord">trả ra tổng số bản ghi.</param>
        /// <returns></returns>
        public List<WordsModel> List(WordsCondition condition, out int totalRecord)
        {
            if(condition.SearchText ==null) condition.SearchText ="";
            var query = (from w in Context.tblWords
                         join t in Context.tblDictTypes on w.Dict_Type equals t.Id
                         where (condition.DictType > 0 ? w.Dict_Type == condition.DictType : true)
                         && w.Del_Flag == false
                         && (condition.SearchText.Length>0? w.Key.Contains(condition.SearchText)|| w.ShortCut.Contains(condition.SearchText)|| w.Value.Contains(condition.SearchText):true)
                         select new WordsModel()
                         {
                             Id = w.Id,
                             Key = w.Key,
                             ShortCut = w.ShortCut,
                             Value = w.Value,
                             ImageUrl = w.ImageUrl,
                             Dict_Type = w.Dict_Type,
                             DictTypeText = t.Text,
                             State = w.State,
                             Update_By = w.Update_By,
                             Update_Date = w.Update_Date
                         });
            var result = query.Skip((condition.page - 1) * condition.pageSize).Take(condition.pageSize).ToList();
            totalRecord = 0;
            if (result != null && result.Count > 0)
            {
                totalRecord = query.Count();
            }
            return result;
        }

        /// <summary>
        /// Lấy danh sách từ vựng theo các điều kiện tìm kiếm.
        /// </summary>
        /// <param name="condition">các điều kiện tìm kiếm</param>
        /// <returns></returns>
        public List<SelectListItem> List(WordsCondition condition)
        {
            if (condition.SearchText == null) condition.SearchText = "";
            var result = (from w in Context.tblWords
                         join t in Context.tblDictTypes on w.Dict_Type equals t.Id
                         where (condition.DictType > 0 ? w.Dict_Type == condition.DictType : true)
                         && w.Del_Flag == false
                         && (condition.SearchText.Length > 0 ? w.Key.Contains(condition.SearchText): true)
                         orderby w.Key
                         select new SelectListItem()
                         {
                             Text = w.Key,
                             Value = w.Id.ToString()
                         }).ToList();
            
            return result;
        }

        /// <summary>
        /// Lấy danh sách lịch sử tìm kiếm theo user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SelectListItem> ListWordHistory(int userId)
        {
            var result = (from wH in Context.tblWordHistories
                          join w in Context.tblWords on wH.Word_Id equals w.Id
                          where wH.User_Id == userId
                          select new SelectListItem()
                          {
                              Value = w.Id.ToString(),
                              Text = w.Key
                          }).ToList();
            return result;
        }

        /// <summary>
        /// Lấy từ theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public WordsModel GetById(int Id)
        {
            var result = (from w in Context.tblWords
                          where w.Id == Id
                          && w.Del_Flag==false
                          select new WordsModel()
                          {
                              Id = w.Id,
                              Key = w.Key,
                              ShortCut = w.ShortCut,
                              Value = w.Value,
                              ImageUrl = w.ImageUrl,
                              Dict_Type = w.Dict_Type,
                              State = w.State,
                              Update_By = w.Update_By,
                              Update_Date = w.Update_Date
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Lấy danh sách các loại từ điển
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListDictType()
        {
            var result = (from d in Context.tblDictTypes
                          where d.IsDisplay
                          select new SelectListItem()
                          {
                              Text = d.Text,
                              Value = d.Id.ToString()
                          }).ToList();
            return result;
        }

        /// <summary>
        /// Xử lý thêm từ vựng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Save(WordsModel model)
        {
            DAL.tblWord word = new tblWord();
            
            if (model.Id > 0)
            {
                // Cập nhật từ vựng
                word = (from w in Context.tblWords
                                    where w.Id == model.Id
                                    select w).FirstOrDefault();
                if (word == null)
                {
                    return (int)Helpers.EnumError.NOT_EXISTS;
                }
            }
            word.Key = model.Key;
            word.ShortCut = model.ShortCut;
            word.Value = model.Value;
            word.ImageUrl = model.ImageUrl;
            word.Dict_Type = model.Dict_Type;
            word.State = model.Display ? 1 : 0;
            word.Update_By = model.Update_By;
            word.Update_Date = DateTime.Now;
            word.Del_By = 0;
            word.Del_Flag = false;
            try
            {
                if (model.Id <= 0)
                {
                    Context.tblWords.InsertOnSubmit(word);
                }
                Context.SubmitChanges();
                string mess = "Xử lý cập nhật từ vựng: " + word.Key + " Bởi: " + model.Update_By;
                Logs.LogWrite(mess, Configs.LOG_EVENT);

                return word.Id;
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật từ vựng: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);

                return (int)EnumError.UPDATE_ERROR; // Trả về lỗi cập nhật.
            }
        }

        /// <summary>
        /// Xử lý xóa từ vựng
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id, int UpdateBy)
        {
            DAL.tblWord word = (from w in Context.tblWords
                                where w.Id == Id
                                select w).FirstOrDefault();
            try
            {
                if (word != null)
                {
                    word.Del_Flag = true;
                    word.Del_By = UpdateBy;
                    Context.SubmitChanges();

                    string mess = "Xử lý xóa từ vựng: " + Id.ToString() + " Bởi: " + UpdateBy.ToString();
                    Logs.LogWrite(mess, Configs.LOG_EVENT);
                    return word.Id;
                }
                else
                {
                    return (int)EnumError.DELETE_ERROR;
                }
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi xóa từ vựng: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);

                return (int)EnumError.DELETE_ERROR; // Trả về lỗi xóa.
            }
        }

        public int DeleteAll()
        {
            try
            {
                var query = (from w in Context.tblWords
                             select w).ToList();
                if (query.Count > 0)
                {
                    Context.tblWords.DeleteAllOnSubmit(query);
                    Context.SubmitChanges();
                }

                return query.Count;
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi xóa từ vựng: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);

                return (int)EnumError.DELETE_ERROR; // Trả về lỗi xóa.
            }
        }

        /// <summary>
        /// Cập nhật trạng thái từ vựng
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="State"></param>
        /// <param name="UpdateBy"></param>
        /// <returns></returns>
        public int UpdateState(int Id, int State, int UpdateBy)
        {
            DAL.tblWord word = (from w in Context.tblWords
                                where w.Id == Id
                                select w).FirstOrDefault();
            try
            {
                if (word != null)
                {
                    word.State = State;
                    word.Update_By = UpdateBy;
                    word.Update_Date = DateTime.Now;
                    Context.SubmitChanges();

                    string mess = "Xử lý cập nhật trạng thái từ vựng: " + Id.ToString() + " Bởi: " + UpdateBy.ToString();
                    Logs.LogWrite(mess, Configs.LOG_EVENT);
                    return word.Id;
                }
                else
                {
                    return (int)EnumError.UPDATE_ERROR;
                }
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật trạng thái: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);

                return (int)EnumError.UPDATE_ERROR; // Trả về lỗi cập nhật.
            }
        }

        public void UpdateWordHistory(int wordId, int userId)
        {
            var wordHistory = (from wH in Context.tblWordHistories
                         where wH.User_Id == userId
                         && wH.Word_Id == wordId
                         select wH).FirstOrDefault();
            
            try
            {
                if (wordHistory == null)
                {
                    wordHistory = new tblWordHistory();
                    wordHistory.Word_Id = wordId;
                    wordHistory.User_Id = userId;
                    wordHistory.Del_Flag = false;
                    wordHistory.Update_Date = DateTime.Now;
                    Context.tblWordHistories.InsertOnSubmit(wordHistory);
                }
                else
                {
                    wordHistory.Del_Flag = false;
                    wordHistory.Update_Date = DateTime.Now;
                }

                Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật lịch sử tra từ: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);
            }
        }

        public int InsertFromExcel(List<WordsModel> listModel)
        {
            try
            {
                using(MTDDataContext dc = new MTDDataContext())
                {
                    var query = (from model in listModel
                                 select new tblWord
                                 {
                                     Dict_Type = model.Dict_Type,
                                    Key = model.Key,
                                    Value = model.Value,
                                    Update_By = model.Update_By,
                                    Update_Date = DateTime.Now,
                                    State = 1,
                                    Del_Flag = false
                                 });

                    dc.tblWords.InsertAllOnSubmit(query);
                    dc.SubmitChanges();
                }
                return listModel.Count;
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật từ vựng: ";
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);

                return (int)EnumError.UPDATE_ERROR; // Trả về lỗi cập nhật.
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTD.DAL;
using MTD.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MTD.Models
{
    public class WordsModel:BaseModel
    {
        // Id
        public int Id { get; set; }

        // Từ khóa
        public string Key { get; set; }

        // Từ viết tắt
        public string ShortCut { get; set; }

        // Nghĩa của từ
        public string Value { get; set; }

        // Đường dẫn ảnh
        public string ImageUrl { get; set; }

        // Kiểu từ điển
        public int Dict_Type { get; set; }

        // Tên kiểu từ điển.
        public string DictTypeText { get; set; }

        // Trạng thái
        // 0: Không hoạt động
        // 1: Đang hoạt động
        public int State { get; set; }

        public bool Display { get; set; }

        // Người cập nhật
        public int Update_By { get; set; }

        // Thời gian cập nhật
        public DateTime Update_Date { get; set; }

        // Trạng thái xóa
        public bool Del_Flag { get; set; }

        // Người xóa
        public int Del_By { get; set; }

        public List<WordsModel> ListWord { get; set; }
        public List<SelectListItem> ListDictType { get; set; }
        public WordsCondition condition { get; set; }

        public WordsModel()
        {
            Display = true;
        }
    }

    public class WordsCondition
    {
        public int Id { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int DictType { get; set; }
        public string SearchText { get; set; }
        public string sortOrder { get; set; }

        // Danh sách từ gợi ý.
        public List<SelectListItem> ListWordSuggest { get; set; }

        public WordsCondition()
        {
            page = 1;
            pageSize = 20;
            ListWordSuggest = new List<SelectListItem>();
        }
    }

    public class WordsUpdateModel : BaseModel
    {
        // Id
        public int Id { get; set; }

        // Từ khóa
        [Required(ErrorMessage="Xin hãy nhập từ khóa")]
        public string Key { get; set; }

        // Từ viết tắt
        public string ShortCut { get; set; }

        // Nghĩa của từ
        [Required(ErrorMessage="Xin hãy nhập nghĩa của từ")]
        public string Value { get; set; }

        // Đường dẫn ảnh
        public string ImageUrl { get; set; }

        // Kiểu từ điển
        public int Dict_Type { get; set; }

        // Trạng thái
        public int State { get; set; }

        // Người cập nhật
        public int Update_By { get; set; }

        // Thời gian cập nhật
        public DateTime Update_Date { get; set; }

        // Trạng thái xóa
        public bool Del_Flag { get; set; }

        // Người xóa
        public int Del_By { get; set; }
    }
}
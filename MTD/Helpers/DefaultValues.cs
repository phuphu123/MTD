using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTD.Helpers
{
    // Lưu các giá trị mặc định
    public static class DefaultValues
    {
        public static List<SelectListItem> ListRole()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Chọn quyền", Value = "-1" });
            list.Add(new SelectListItem() { Text = "Thành viên thường", Value = "1" });
            list.Add(new SelectListItem() { Text = "Quản lý", Value = "777" });
            return list;
        }

        /// <summary>
        /// Danh sách trạng thái hoạt động
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ListState()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Tất cả trạng thái", Value = "-1" });
            list.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
            list.Add(new SelectListItem() { Text = "Đang hoạt động", Value = "1" });
            return list;
        }

        /// <summary>
        /// Danh sách giới tính.
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ListGender()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Chưa rõ", Value = "0" });
            list.Add(new SelectListItem() { Text = "Nam", Value = "1" });
            list.Add(new SelectListItem() { Text = "Nữ", Value = "2" });
            return list;
        }
    }
}
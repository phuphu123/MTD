using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MTD.Models
{
    public class UserModel:BaseModel
    {   
        public int Id { get; set; }

        // Id tài khoản sử dụng
        public int AccountId { get; set; }

        // Tên đăng nhập
        public string UserName { get; set; }

        // Tên hiển thị
        public string DisplayName { get; set; }

        // Họ & tên đệm
        public string FirstName { get; set; }

        // Tên
        public string LastName { get; set; }

        // Giới tính (0: Chưa rõ, 1: Nam giới, 2: Nữ giới
        public int Gender { get; set; }

        // Ngày sinh
        public string DateOfBirth { get; set; }

        // Địa chỉ
        public string Address { get; set; }

        // Tỉnh / Thành phố
        public int CityId { get; set; }

        // Quận / Huyện
        public int DistrictId { get; set; }

        // Thị trấn / Phường / Xã
        public int VillageId { get; set; }

        // Ảnh đại diện
        public string Avatar { get; set; }

        // Số điện thoại
        public string PhoneNumber { get; set; }

        // Mô tả
        public string Description { get; set; }

        // Trạng thái (1: Đang hoạt động, 0: không hoạt động)
        public int State { get; set; }

        // Người cập nhật
        public int Update_By { get; set; }

        // Ngày cập nhật.
        public DateTime Update_Date { get; set; }

        // Trạng thái xóa.
        public bool Del_Flag { get; set; }
        // More Info.


        // Danh sách tỉnh/ thành phố
        public List<SelectListItem> ListCity { get; set; }

        // Danh sách quận/ huyện
        public List<SelectListItem> ListDistrict { get; set; }

        // Danh sách xã/ phường/ thị trấn.
        public List<SelectListItem> ListVillage { get; set; }

        public List<UserModel> ListUser { get; set; }

        public UserModel()
        {
            DateOfBirth = DateTime.Now.AddYears(-18).ToString();
            ListCity = new List<SelectListItem>();
            ListDistrict = new List<SelectListItem>();
            ListVillage = new List<SelectListItem>();

            ListUser = new List<UserModel>();
        }
    }

    public class UserCondition : BaseModel
    {
        // Từ khóa tìm kiếm (họ tên, địa chỉ, số điện thoại)
        public string key { get; set; }

        // Tìm theo ngày sinh (bắt đầu)
        public DateTime birth_start { get; set; }

        // Tìm theo ngày sinh (kết thúc)
        public DateTime birth_end { get; set; }

        // Tìm theo giới tính.
        public int gender { get; set; }

        // Tìm theo địa lý
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int VillageId { get; set; }

        public UserCondition()
        {
            key = "";
            birth_start = DateTime.Now.AddYears(-50);
            birth_end = DateTime.Now.AddYears(-20);
        }
    }

    public class UserAccountModel: BaseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int AccountId { get; set; }

        public List<SelectListItem> ListAccount { get; set; }
    }

}
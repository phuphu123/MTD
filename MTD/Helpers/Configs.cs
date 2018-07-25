using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTD.Helpers
{
    public class Configs
    {
        // Log events.
        public const string LOG_EVENT = "Events.txt";

        // Url
        public static string URL_PHYSICAL_AVATAR = HttpContext.Current.Server.MapPath("~\\Content\\Uploads\\Images\\{0}\\Avatar\\");
        public static string URL_PHYSICAL_TEMPLATE = HttpContext.Current.Server.MapPath("~\\Content\\Templates\\{0}");
        public const string URL_IMAGE_AVATAR = "~/Content/Uploads/Images/{0}/Avatar/{1}";

        // Cookie 
        public const string COOKIES_USERNAME = "UserName";
        public const string COOKIES_ACCOUNT_ID = "AccountID";
        public const string COOKIES_ROLE_ID = "RoleID";
        public const string COOKIES_ADMIN = "Admin";

        public const string TEMP_MESSAGE = "MESSAGE";
        public const string TEMP_REDIRECT = "REDIRECT";
        
        // Alert
        public const string ALERT_NOT_ALLOW = "Bạn không được phép truy cập chức năng này.";
        public const string ALERT_NOT_CHOICE = "Bạn chưa chọn đối tượng nào.";

        // Confirm
        public const string CONFIRM_DELETE_ACCOUNTS = "Bạn có chắc chắn muốn xóa tài khoản này không?";
        public const string CONFIRM_LOGOUT ="Bạn có muốn thoát không?";
        public const string CONFIRM_DELETE_WORD = "Bạn có chắc chắn muốn xóa từ này không?";
        public const string CONFIRM_DELETE_USERS = "Bạn có chắc chắn muốn xóa người này không?";

        // Error
        public const string ERROR_DELETE = "Xóa không thành công";
        public const string ERROR_NOT_DATA = "Không có dữ liệu";
        public const string ERROR_EXISTS_ACCOUNT = "Tài khoản bạn chọn đã tồn tại. Xin xem lại Username hoặc Email.";
        public const string ERROR_NOT_EXISTS_ACCOUNT = "Tài khoản username hoặc email chưa tồn tại";
        public const string ERROR_PROCESS = "Lỗi xử lý dữ liệu";
        public const string ERROR_NOT_FOUND_ACCOUNT = "Không tìm thấy tài khoản phù hợp.";
        public const string ERROR_LOGIN = "Thông tin đăng nhập không khớp. Xin vui lòng xem lại.";
        public const string ERROR_UPDATE = "Cập nhật thất bại";
        public const string ERROR_FORMAT_FILE = "File của bạn có lỗi, xin vui lòng xem lại dòng: {0}";
        public const string ERROR_NOT_CHOICE_FILE = "Bạn chưa chọn file!";
        public const string ERROR_RECOVERY = "Khôi phục thất bại!";

        // Success
        public const string SUCCESS_REGISTRY = "Xin chúc mừng! bạn đã đăng ký thành công.";
        public const string SUCCESS_INSERT = "Bạn đã thêm thành công";
        public const string SUCCESS_UPDATE = "Bạn đã cập nhật thành công";
        public const string SUCCESS_DELETE = "Xóa thành công";
        public const string SUCCESS_LOGIN = "Xin chúc mừng! Bạn đã đăng nhập thành công.";
        public const string SUCCESS_RECOVERY = "Bạn đã khôi phục thành công!";

        // Message

    }
}
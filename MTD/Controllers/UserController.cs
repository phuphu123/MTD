using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTD.Models;
using MTD.Helpers;
using MTD.Services;

namespace MTD.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Account        

        /// <summary>
        /// Đăng ký
        /// </summary>
        /// <returns></returns>
        public ActionResult Registry()
        {
            AccountModel model = new AccountModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Registry(AccountModel model)
        {
            AccountService service = new AccountService();
            if (ModelState.IsValid)
            {
                // Kiểm tra sự tồn tại của username hoặc email đăng ký.
                // Nếu đã tồn tại thì đưa ra thông báo lỗi.
                var chk = service.CheckExistsAccount(model.UserName, model.Email);
                if (chk)
                {
                    model.Message = Configs.ERROR_EXISTS_ACCOUNT;
                    model.Code = -3;
                    model.Result = false;
                    SetTempData(model.Message);
                    return View(model);
                }

                // Cập nhật vào bảng tblAccount.
                string guid = Guid.NewGuid().ToString();
                model.Active_Code = guid;
                model.RoleId = 1;
                int result = service.Insert(model);
                if (result > 0)
                {
                    model.Result = true;
                    model.Message = Configs.SUCCESS_REGISTRY;
                    model.Redirect = Url.Action("Index","Words");
                    SetTempData(model.Message, model.Redirect);
                    return View(model);
                }
                else
                {
                    model.Result = false;
                    model.Message = GetErrorMessage(result);
                    SetTempData(model.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            AccountService service = new AccountService();
            if (ModelState.IsValid)
            {
                // Kiểm tra sự tồn tại của Username, email.
                bool chk = service.CheckExistsAccount(model.UserName);
                if (chk)
                {
                    // Kiểm tra thông tin đăng nhập.
                    var aId = service.CheckLogin(model.UserName, model.Password);
                    if (aId > 0)
                    {
                        AccountModel accModel = new AccountModel();
                        accModel = service.GetAccountById(aId);

                        // Set Cookie cho tài khoản
                        int dayExpires = model.Remember ? 365 : 1;
                        InitAccount(accModel, dayExpires);

                        // Thông báo đăng nhập thành công & redirect.
                        model.Message = Configs.SUCCESS_LOGIN;
                        model.Redirect = Url.Action("Index", "Words");
                        SetTempData(model.Message, model.Redirect);
                    }
                    else
                    {
                        model.Message = Configs.ERROR_LOGIN;
                        SetTempData(model.Message);
                    }
                }
                else
                {
                    model.Message = Configs.ERROR_NOT_EXISTS_ACCOUNT;
                    SetTempData(model.Message);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <returns></returns>
        public ActionResult DoLogout()
        {
            RemoveAccount();

            return Redirect("~");
        }

        /// <summary>
        /// Danh sách tài khoản.
        /// Chỉ có Admin mới được xem danh sách này.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListAccount(AccountCondition Condition)
        {
            AccountService service = new AccountService();
            AccountModel model = new AccountModel();
            model.ListAccount = new List<AccountModel>();

            // Lấy danh sách quyền.
            model.ListRole = DefaultValues.ListRole();

            // Lấy danh sách trạng thái.
            model.ListState = DefaultValues.ListState();

            // Gán điều kiện vào model.
            model.Condition = Condition;

            // Kiểm tra quyền xem danh sách tài khoản.
            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }
            // Lấy danh sách tài khoản theo điều kiện tìm kiếm.
            model.ListAccount = service.List(Condition);

            // Phân trang
            int total = 0;
            if(model.ListAccount.Count>0){
                total = model.ListAccount[0].Total;
            }
            Paging(Condition.page, Condition.pageSize, total);

            return View(model);
        }

        /// <summary>
        /// Màn hình tạo tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            AccountModel model = new AccountModel();
            model.ListRole = DefaultValues.ListRole();
            if (!IsAdmin())
            {
                SetRedirectNotAllow();
            }
            return View(model);
        }

        /// <summary>
        /// Xử lý tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            model.ListRole = DefaultValues.ListRole();
            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService();
                // Kiểm tra sự tồn tại của username hoặc email đăng ký.
                // Nếu đã tồn tại thì đưa ra thông báo lỗi.
                var chk = service.CheckExistsAccount(model.UserName, model.Email);
                if (chk)
                {
                    model.Message = Configs.ERROR_EXISTS_ACCOUNT;
                    model.Code = -3;
                    model.Result = false;
                    SetTempData(model.Message);
                    return View(model);
                }

                // Cập nhật vào bảng tblAccount.
                string guid = Guid.NewGuid().ToString();
                model.Active_Code = guid;
                int result = service.Insert(model);
                if (result > 0)
                {
                    model.Result = true;
                    model.Message = Configs.SUCCESS_REGISTRY;
                    model.Redirect = Url.Action("ListAccount", "User");
                    SetTempData(model.Message, model.Redirect);
                    return View(model);
                }
                else
                {
                    model.Result = false;
                    model.Message = GetErrorMessage(result);
                    SetTempData(model.Message);
                    return View(model);
                }
            }
            return View(model);
        }
        
        /// <summary>
        /// Màn hình cập nhật tài khoản
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateAccount(int Id)
        {
            AccountService service = new AccountService();
            AccountUpdateModel model = new AccountUpdateModel();
            model = service.GetAccountUpdateById(Id);
            if (model == null) model = new AccountUpdateModel();
            model.ListRole = DefaultValues.ListRole();
            return View(model);
        }

        /// <summary>
        /// Xử lý cập nhật tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateAccount(AccountUpdateModel model)
        {
            model.ListRole = DefaultValues.ListRole();
            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService();
                AccountModel accModel = new AccountModel();
                model.Mapping(model, ref accModel);
                int result = service.UpdateAccount(accModel);
                if (result > 0)
                {
                    model.Result = true;
                    model.Message = Configs.SUCCESS_UPDATE;
                    model.Redirect = Url.Action("ListAccount", "User");
                    SetTempData(model.Message, model.Redirect);
                    return View(model);
                }
                else
                {
                    model.Result = false;
                    model.Message = GetErrorMessage(result);
                    SetTempData(model.Message);
                    return View(model);
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            }

            return View(model);
        }

        /// <summary>
        /// Xử lý xóa tài khoản
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteAccount(int Id)
        {
            if (!IsAdmin())
            {
                return Json(-1);
            }
            AccountService service = new AccountService();
            int result = service.UpdateDelFlag(Id);
            return Json(result);
        }

        /// <summary>
        /// Xử lý khôi phục tài khoản bị xóa.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult RecoveryAccount(int Id)
        {
            if (!IsAdmin())
            {
                return Json(-1);
            }
            AccountService service = new AccountService();
            int result = service.UpdateDelFlag(Id, false);
            return Json(result);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteMultiple(int[] usersDelete)
        {
            if (!IsAdmin())
            {
                return Json(-1);
            }
            AccountService service = new AccountService();
            int result = service.DeleteMultiple(usersDelete);
            return Json(result);
        }
        #endregion

        #region User

        /// <summary>
        /// Màn hình danh sách user.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListPersonal(UserCondition condition)
        {
            UserService service = new UserService();
            PlaceService placeService = new PlaceService();
            UserModel model = new UserModel();

            // Khởi tạo danh sách người dùng.
            model.ListUser = new List<UserModel>();

            // Khởi tạo danh sách giới tính

            // Khởi tạo danh sách tỉnh
            model.ListCity = placeService.ListItem(0);

            if (!IsAdmin())
            {
                SetRedirectNotAllow();
                return View(model);
            }
            model.ListUser = service.List(condition);
            return View(model);
        }

        /// <summary>
        /// Màn hình thông tin cá nhân người dùng.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PersonalInformation(int Id, int AccountId)
        {
            UserService service = new UserService();
            UserModel model = new UserModel();
            if (Id > 0)
            {
                model = service.GetById(Id);
            }

            if (AccountId > 0)
            {
                model = service.GetByAccountId(AccountId);
                if (model == null)
                {
                    model = new UserModel();
                }
            }
            DateTime temp = Convert.ToDateTime(model.DateOfBirth);
            model.DateOfBirth = temp.ToString("dd/MM/yyyy");

            // Lấy danh sách địa lý hành chính.
            GetPlace(ref model);

            return View(model);
        }

        /// <summary>
        /// Xử lý thông tin cá nhân
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PersonalInformation(UserModel model)
        {
            // Cập nhật thông tin địa lý.
            GetPlace(ref model);

            if (ModelState.IsValid)
            {
                UserService service = new UserService();
                int userId = 0;
                int.TryParse(CookieHelper.Get(Configs.COOKIES_ACCOUNT_ID), out userId);
                model.Update_By = userId;

                // Cập nhật thông tin cá nhân.
                int result = service.Update(model);
                if (result > 0)
                {
                    model.Message = Configs.SUCCESS_UPDATE;
                    model.Code = result;
                    model.Result = true;
                    model.Redirect = Url.Action("ListPersonal", "User");
                    SetTempData(model.Message, model.Redirect);
                }
                else
                {
                    model.Message = Configs.ERROR_PROCESS;
                    model.Code = (int)EnumError.UPDATE_ERROR;
                    model.Result = false;
                    SetTempData(model.Message);
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                ViewBag.Message = Configs.ERROR_UPDATE;
                Logs.LogWrite("Lỗi cập nhật thông tin cá nhân: " + errors, "Front_End_Logs.txt");
            }

            return View(model);
        }

        /// <summary>Lấy danh sách địa lý hành chính.
        /// </summary>
        /// <param name="model"></param>
        public void GetPlace(ref UserModel model)
        {
            PlaceService placeService = new PlaceService();

            // Danh sách tỉnh / thành phố.
            model.ListCity = placeService.ListItem(0);

            // Danh sách quận/ huyện.
            if (model.CityId > 0)
            {
                model.ListDistrict = placeService.ListItem(model.CityId);
            }

            // Danh sách xã/ phường/ thị trấn.
            if (model.DistrictId > 0)
            {
                model.ListVillage = placeService.ListItem(model.DistrictId);
            }
        }

        /// <summary>
        /// Màn hình cập nhật tài khoản cho người dùng.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="FullName"></param>
        /// <returns></returns>
        public ActionResult SetAccount(int userId, string FullName)
        {
            UserAccountModel model = new UserAccountModel();
            UserService service = new UserService();
            model.Id = userId;
            model.FullName = FullName;

            model.ListAccount = service.ListAccountNotUsing();

            return PartialView("SetAccountForm", model);
        }

        /// <summary>
        /// Xử lý cập nhật tài khoản người dùng.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetAccount(UserAccountModel model)
        {
            UserService service = new UserService();
            model.ListAccount = service.ListAccountNotUsing();

            int result = service.UpdateAccountUser(model);
            if (result > 0)
            {
                model.Message = Configs.SUCCESS_UPDATE;
                model.Result = true;
            }
            else
            {
                model.Message = Configs.ERROR_UPDATE;
                model.Result = false;
            }

            return PartialView("SetAccountForm", model);
        }
        #endregion
    }
}

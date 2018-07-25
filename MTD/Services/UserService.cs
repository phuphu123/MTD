using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTD.Models;
using MTD.DAL;
using MTD.Helpers;
using System.Web.Mvc;

namespace MTD.Services
{
    public class UserService: BaseService
    {
        public UserService() : base() { }

        /// <summary>
        /// Lấy thông tin người dùng theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserModel GetById(int Id)
        {
            var result = (from u in Context.tblUsers
                          where u.Id == Id
                          select new UserModel()
                          {
                              Id = u.Id,
                              AccountId = u.AccountId,
                              DisplayName = u.DisplayName,
                              FirstName = u.FirstName,
                              LastName   = u.LastName,
                              Gender = u.Gender,
                              DateOfBirth = u.DateOfBirth.ToString(),
                              Address = u.Address,
                              CityId = u.CityId,
                              DistrictId = u.DistrictId,
                              VillageId = u.VillageId,
                              Avatar = u.Avatar,
                              PhoneNumber = u.PhoneNumber,
                              Description = u.Description,
                              State = u.State,
                              Update_By = u.Update_By,
                              Update_Date = u.Update_Date.GetValueOrDefault(),
                              Del_Flag = u.Del_Flag
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Lấy thông tin người dùng theo tài khoản.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public UserModel GetByAccountId(int accountId)
        {
            var query = (from a in Context.tblAccounts
                          join u in Context.tblUsers on a.Id equals u.AccountId into tUser
                          from newU in tUser.DefaultIfEmpty()
                          where a.Id == accountId
                          select (newU.AccountId!=null? newU.AccountId:0)).FirstOrDefault();
            if (query > 0)
            {
                var result = (from a in Context.tblAccounts
                              join u in Context.tblUsers on a.Id equals u.AccountId into tUser
                              from newU in tUser.DefaultIfEmpty()
                              where a.Id == accountId
                              select new UserModel()
                              {
                                  Id = newU.Id,
                                  UserName = a.UserName,
                                  AccountId = newU.AccountId,
                                  DisplayName = newU.DisplayName,
                                  FirstName = newU.FirstName,
                                  LastName = newU.LastName,
                                  Gender = newU.Gender,
                                  DateOfBirth = newU.DateOfBirth.ToString(),
                                  Address = newU.Address,
                                  CityId = newU.CityId,
                                  DistrictId = newU.DistrictId,
                                  VillageId = newU.VillageId,
                                  Avatar = newU.Avatar,
                                  PhoneNumber = newU.PhoneNumber,
                                  Description = newU.Description,
                                  State = newU.State,
                                  Update_By = newU.Update_By,
                                  Update_Date = newU.Update_Date.GetValueOrDefault(),
                                  Del_Flag = newU.Del_Flag
                              }).FirstOrDefault();
                return result;
            }

            return new UserModel();
        }

        public int Update(UserModel model)
        {
            try
            {
                tblUser user = Context.tblUsers.Where(e => e.AccountId == model.AccountId).FirstOrDefault();
                bool isInsert = false;
                if (user == null)
                {
                    user = new tblUser();
                    isInsert = true;
                }
                user.AccountId = model.AccountId;
                user.DisplayName = model.DisplayName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd/MM/yyyy", null);
                user.Address = model.Address;
                user.CityId = model.CityId;
                user.DistrictId = model.DistrictId;
                user.VillageId = model.VillageId;
                user.Avatar = model.Avatar;
                user.PhoneNumber = model.PhoneNumber;
                user.Description = model.Description;
                user.State = 1;
                user.Update_By = model.Update_By;
                user.Update_Date = DateTime.Now;
                user.Del_Flag = model.Del_Flag;
                if (isInsert)
                {
                    Context.tblUsers.InsertOnSubmit(user);
                }
                Context.SubmitChanges();
                return user.Id;

            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật thông tin cá nhân Id: " + model.Id;
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);
                return (int)EnumError.UPDATE_ERROR;
            }
        }

        public List<UserModel> List(UserCondition condition)
        {
            var query = (from u in Context.tblUsers
                         join a in Context.tblAccounts on u.AccountId equals a.Id into acc
                         from newAcc in acc.DefaultIfEmpty()
                         where 1 == 1
                         select new UserModel()
                         {
                             Id = u.Id,
                             UserName = newAcc.UserName,
                             AccountId = u.AccountId,
                             DisplayName = u.DisplayName,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Gender = u.Gender,
                             DateOfBirth = u.DateOfBirth.ToString(),
                             Address = u.Address,
                             CityId = u.CityId,
                             DistrictId = u.DistrictId,
                             VillageId = u.VillageId,
                             Avatar = u.Avatar,
                             PhoneNumber = u.PhoneNumber,
                             Description = u.Description,
                             State = u.State,
                             Update_By = u.Update_By,
                             Update_Date = u.Update_Date.GetValueOrDefault(),
                             Del_Flag = u.Del_Flag
                         }).ToList();

            if (query.Count > 0)
            {
                foreach (var user in query)
                {
                    DateTime temp = Convert.ToDateTime(user.DateOfBirth);
                    user.DateOfBirth = temp.ToString("dd/MM/yyyy");
                }
            }
            return query;

        }

        /// <summary>
        /// Lấy danh sách các tài khoản chưa có người sử dụng.
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListAccountNotUsing()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem() { Text = "", Value = "0" });

            // Lấy danh sách những tài khoản đã được sử dụng.
            var listAccountUsing = (from u in Context.tblUsers
                          join a in Context.tblAccounts on u.AccountId equals a.Id
                          select a.Id).ToList();
            // Lấy toàn bộ tài khoản đang được hoạt động
            var listAllAccount = (from a in Context.tblAccounts
                                  where a.State == 1
                                  select new SelectListItem { 
                                    Value = a.Id.ToString(),
                                    Text = a.UserName + " - " + a.Email
                                  }
                                  ).ToList();
            foreach (var acc in listAllAccount)
            {
                if (!listAccountUsing.Contains(int.Parse(acc.Value)))
                {
                    result.Add(acc);
                }
            }
            return result;
        }

        /// <summary>
        /// Xử lý cập nhật tài khoản cho user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAccountUser(UserAccountModel model)
        {
            try
            {
                tblUser user = Context.tblUsers.Where(e => e.Id == model.Id).FirstOrDefault();
                if (user == null)
                {
                    return (int)EnumError.NOT_EXISTS;
                }
                user.AccountId = model.AccountId;

                Context.SubmitChanges();
                return user.Id;
            }
            catch (Exception ex)
            {
                string strErr = "Lỗi cập nhật thông tin tài khoản Id: " + model.Id;
                strErr += "\\n" + ex.ToString();
                Logs.LogWrite(strErr);
                return (int)EnumError.UPDATE_ERROR;
            }
        }
    }
}
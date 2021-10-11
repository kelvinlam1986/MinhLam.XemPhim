using Microsoft.AspNetCore.Mvc;
using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Admin.InputModel;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Application.Commands;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;
using MinhLam.XemPhim.Web.Attributes;
using MinhLam.XemPhim.Web.Extensions;
using System;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly IUserQuery userQuery;
        private readonly IAccountService accountService;

        public UserController(
            IUserQuery userQuery,
            IAccountService accountService)
        {
            this.userQuery = userQuery;
            this.accountService = accountService;
        }

        [WithRole(RoleNames = "VIEW_USER_READONLY")]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var userGroups = this.userQuery.GetAccountGroups();
            ViewBag.UserGroups = userGroups;
            var userList = this.userQuery.GetPagedList(page, pageSize);
            return View(userList);
        }

        [HttpGet]
        [WithRole(RoleNames = "VIEW_USER_READONLY,INSERT_USER")]
        public ActionResult New()
        {
            var newAccount = new AccountDTO();
            var userGroups = this.userQuery.GetAccountGroups();
            ViewBag.UserGroups = userGroups;

            return View(newAccount);
        }

        [HttpGet]
        [WithRole(RoleNames = "VIEW_USER_READONLY,UPDATE_USER")]
        public ActionResult Edit(Guid? id)
        {
            var userGroups = this.userQuery.GetAccountGroups();
            ViewBag.UserGroups = userGroups;

            if (id == null)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Index");
            }

            var account = this.userQuery.GetAccountById(id.Value);
            if (account == null)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Index");
            }

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,UPDATE_USER")]
        public IActionResult Update(EditAccountDto inputAccount)
        {
            try
            {
                var userGroups = this.userQuery.GetAccountGroups();
                ViewBag.UserGroups = userGroups;

                if (ModelState.IsValid)
                {
                    var updateAccountCommand = new UpdateAccountCommand(
                        inputAccount.Id, inputAccount.Name, inputAccount.Phone, inputAccount.IsActive, inputAccount.GroupId);
                    this.accountService.Update(updateAccountCommand);
                    SetAlert("Cập nhật tài khoản thành công!", "success");
                    return RedirectToAction("Index");
                }

                return View("Edit");
            }
            catch (DomainException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Edit");
            }
            catch (ApplicationServiceException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Edit");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", OperationExceptionCodes.Message);
                return View("Edit");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,INSERT_USER")]
        public IActionResult Create(AccountDTO inputAccount)
        {
            try
            {
                var userGroups = this.userQuery.GetAccountGroups();
                ViewBag.UserGroups = userGroups;

                if (ModelState.IsValid)
                {
                    var newAccountCommand = new AddNewAccountCommand(
                        inputAccount.Username,
                        inputAccount.Password,
                        inputAccount.Name,
                        inputAccount.Email,
                        inputAccount.Phone,
                        inputAccount.IsActive,
                        inputAccount.GroupId);
                    this.accountService.AddNew(newAccountCommand);
                    SetAlert("Tạo tài khoản thành công!", "success");
                    return RedirectToAction("Index");
                }

                return View("New");
            }
            catch (DomainException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("New");
            }
            catch (ApplicationServiceException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("New");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", OperationExceptionCodes.Message);
                return View("New");
            }

        }

        [WithRole(RoleNames = "INSERT_USER,UPDATE_USER")]
        public ActionResult Add(AccountDTO model, string submit)
        {
            if (ModelState.IsValid)
            {
                if (submit == "Thêm")
                {
                    if (model != null)
                    {
                        //model.Name = model.Name.ToString();
                        //model.UserName = model.UserName.ToString();
                        //model.Password = Encryptor.MD5Hash(model.Password.ToString());
                        //model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                        //model.Status = model.Status;
                        //model.GroupID = model.GroupID.ToString();
                        //db.Users.Add(model);
                        //db.SaveChanges();
                        //model = null;

                    }
                    //List<UserGroup> listper = db.UserGroups.ToList();
                    //ViewBag.listuser = listper;
                    //List<User> list = GetData();
                    //ViewBag.list = list;
                    //SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index");
                }
                else if (submit == "Cập Nhật")
                {
                    if (model != null)
                    {
                        //var listupdate = db.Users.SingleOrDefault(x => x.UserID == model.UserID);
                        //listupdate.Name = model.Name;
                        //listupdate.UserName = model.UserName;
                        //listupdate.Password = Encryptor.MD5Hash(model.Password);
                        //listupdate.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                        //listupdate.Status = model.Status;
                        //model.GroupID = model.GroupID;
                        //db.SaveChanges();
                        //model = null;
                    }
                    //List<UserGroup> listper = db.UserGroups.ToList();
                    //ViewBag.listuser = listper;
                    //List<User> list = GetData();
                    //ViewBag.list = list;
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index");
                }
                else if (submit == "Tìm")
                {
                    //if (!string.IsNullOrEmpty(model.UserName))
                    //{
                    //    List<User> list = GetData().Where(s => s.UserName.Contains(model.UserName)).
                    //        ToList();
                    //    return View("Index", list);
                    //}
                    //else
                    //{
                    //    List<User> list = GetData();
                    //    return View("Index", list);
                    //}
                }
                else
                {
                    //List<User> list = GetData().OrderBy(s => s.Name).ToList();
                    //return View("Index", list);
                }
            }

            var newAccount = new AccountDTO();
            var userGroups = this.userQuery.GetAccountGroups();
            ViewBag.UserGroups = userGroups;
            return PartialView("_UserModal", newAccount);
        }
    }
}

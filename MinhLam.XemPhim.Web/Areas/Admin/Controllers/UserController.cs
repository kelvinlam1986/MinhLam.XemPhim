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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,DELETE_USER")]
        public IActionResult Delete(RemoveAccountDto inputAccount)
        {
            try
            {
                var removeAccountCommand = new RemoveAccountCommand(inputAccount.Id);
                this.accountService.Remove(removeAccountCommand);
                SetAlert("Xóa tài khoản thành công!", "success");
                return RedirectToAction("Index");
            }
            catch (DomainException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }
            catch (ApplicationServiceException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,UPDATE_USER")]
        public IActionResult ToggleActive(ToggleActiveAccountDto inputAccount)
        {
            try
            {
                var toggleActiveCommand = new ToggleActiveAccountCommand(inputAccount.Id);
                this.accountService.ToggleActive(toggleActiveCommand);
                string message = inputAccount.IsActive ? "Bỏ kích hoạt " : "Kích hoạt"; 
                SetAlert($"{message} tài khoản thành công!", "success");
                return RedirectToAction("Index");
            }
            catch (DomainException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }
            catch (ApplicationServiceException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Index");
            }
        }
    }
}

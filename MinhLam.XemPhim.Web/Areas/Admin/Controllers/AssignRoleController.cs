using Microsoft.AspNetCore.Mvc;
using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Admin.InputModel;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Application.Commands;
using MinhLam.XemPhim.Domain;
using MinhLam.XemPhim.Domain.Repositories;
using MinhLam.XemPhim.Web.Attributes;
using System;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssignRoleController : BaseController
    {
        private readonly IUserQuery userQuery;
        private readonly IAccountService accountService;
        private readonly IGetData getData;
        private readonly IAccountRepository accountRepository;

        public AssignRoleController(
            IUserQuery userQuery,
            IAccountService accountService,
            IAccountRepository accountRepository,
            IGetData getData)
        {
            this.userQuery = userQuery;
            this.accountService = accountService;
            this.accountRepository = accountRepository;
            this.getData = getData;
        }

        [WithRole(RoleNames = "VIEW_USER_READONLY, INSERT_USER, UPDATE_USER")]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var userGroups = this.userQuery.GetAccountGroups();
            ViewBag.UserGroups = userGroups;
            var userList = this.userQuery.GetPagedList(page, pageSize);
            return View(userList);
        }

        [WithRole(RoleNames = "VIEW_USER_READONLY, INSERT_USER, UPDATE_USER")]
        public IActionResult Configure(Guid? id)
        {
            if (id == null)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Index");
            }

            var userRole = this.userQuery.GetUserRolesOfAccount(id.Value);
           
            if (userRole == null)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Index");
            }

            ViewBag.UserRole = userRole;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,UPDATE_USER")]
        public IActionResult DeleteUserRole(RemoveUserRoleDto inputModel)
        {
            try
            {
                var removeUserRoleCommand = new RemoveUserRoleCommand(inputModel.UserId, inputModel.Id);
                this.accountService.RemoveUserRole(removeUserRoleCommand);
                SetAlert("Xóa vai trò thành công!", "success");
                return RedirectToAction("Configure", new { id = inputModel.UserId });
            }
            catch (DomainException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Configure", new { id = inputModel.UserId });
            }
            catch (ApplicationServiceException e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Configure", new { id = inputModel.UserId });
            }
            catch (Exception e)
            {
                SetAlert(e.Message, "danger");
                return RedirectToAction("Configure", new { id = inputModel.UserId });
            }
        }

        [WithRole(RoleNames = "VIEW_USER_READONLY, INSERT_USER, UPDATE_USER")]
        public IActionResult AddUserRole(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Configure", new { id = userId });
            }

            var user = this.accountRepository.GetById(userId);
            if (user == null)
            {
                SetAlert("Không tìm thấy tài khoản", "error");
                return RedirectToAction("Configure", new { id = userId });
            }

            var addUserRoleDto = new AddUserRoleDto();
            addUserRoleDto.UserId = user.Id;
            addUserRoleDto.Username = user.Username;

            var roles = this.getData.GetRoles();
            ViewBag.Roles = roles;
            return View(addUserRoleDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [WithRole(RoleNames = "VIEW_USER_READONLY,UPDATE_USER")]
        public IActionResult InsertUserRole(AddUserRoleDto inputModel)
        {
            var roles = this.getData.GetRoles();
            ViewBag.Roles = roles;
            var addUserRoleDto = new AddUserRoleDto();
            addUserRoleDto.UserId = inputModel.UserId;
            addUserRoleDto.Username = inputModel.Username;

            try
            {
                if (ModelState.IsValid)
                {
                    var addUserRoleCommand = new AddUserRoleCommand(inputModel.UserId, inputModel.RoleName);
                    this.accountService.AddUserRole(addUserRoleCommand);
                    SetAlert("Tạo role thành công!", "success");
                    return RedirectToAction("Configure", new { id = inputModel.UserId });
                }
             
                return View("AddUserRole", addUserRoleDto);
            }
            catch (DomainException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("AddUserRole", addUserRoleDto);
            }
            catch (ApplicationServiceException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("AddUserRole", addUserRoleDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", OperationExceptionCodes.Message);
                return View("AddUserRole", addUserRoleDto);
            }
        }
    }
}

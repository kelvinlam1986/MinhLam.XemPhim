using Microsoft.AspNetCore.Mvc;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Web.Attributes;
using System;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssignRoleController : BaseController
    {
        private readonly IUserQuery userQuery;
        private readonly IAccountService accountService;

        public AssignRoleController(
            IUserQuery userQuery,
            IAccountService accountService)
        {
            this.userQuery = userQuery;
            this.accountService = accountService;
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
    }
}

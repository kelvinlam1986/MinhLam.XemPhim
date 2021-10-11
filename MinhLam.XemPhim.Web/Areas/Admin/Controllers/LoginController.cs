using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Commands;
using MinhLam.XemPhim.Web.Areas.Admin.Models;
using MinhLam.XemPhim.Web.Common;
using MinhLam.XemPhim.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IAccountQuery accountQuery;
        private readonly IUserRolesQuery userRolesQuery;

        public LoginController(
            IAccountService accountService,
            IAccountQuery accountQuery,
            IUserRolesQuery userRolesQuery)
        {
            this.accountService = accountService;
            this.accountQuery = accountQuery;
            this.userRolesQuery = userRolesQuery;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginCommand = new LoginCommand(model.UserName, model.Password, true);
                    this.accountService.Login(loginCommand);
                    var account = this.accountQuery.GetAccountByUsername(model.UserName);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Tài khoản không tôn tại");
                        return View("Index");
                    }

                    var userSession = new UserLogin(
                        account.Id.ToString(), 
                        account.Username, 
                        account.Name,
                        Convert.ToInt32(account.UserType),
                        account.Email);
                    var userRoles = this.userRolesQuery.GetUserRolesByAccount(account.Id);
                    var roles = new List<string>();
                    if (userRoles != null  && userRoles.Count > 0)
                    {
                        roles = userRoles.Select(x => x.RoleName).ToList();
                    }

                    HttpContext.Session.Set(CommonContants.USER_SESSION, userSession);
                    HttpContext.Session.Set(CommonContants.USER_ROLES, roles);
                  
                    return RedirectToAction("Index", "Home");

                }
                catch (ApplicationServiceException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", OperationExceptionCodes.Message);
                }
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Admin/Login");
        }
    }
}

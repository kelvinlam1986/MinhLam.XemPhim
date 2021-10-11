using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Web.Common;
using MinhLam.XemPhim.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.XemPhim.Web.Attributes
{
    public class WithRoleAttribute : Attribute, IAuthorizationFilter
    {
        public string RoleNames { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session.GetObject<UserLogin>(CommonContants.USER_SESSION);
            if (session == null)
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectToRouteResult(
                     new { controller = "Login", action = "Index", Area = "Admin" });
                return;
            }

            var userRoles = context.HttpContext.Session.GetObject<List<string>>(CommonContants.USER_ROLES);
            var roleNames = RoleNames.Split(",");
            Array.ForEach(roleNames, role => role.Trim());

            if (session.UserType == (int)UserType.Admin)
            {
                return;
            }

            foreach (var roleName in roleNames)
            {
                if (userRoles.Contains(roleName))
                {
                    return;
                }
            }

            HandleUnauthorizeRequest(context);
            return;
        }

        private void HandleUnauthorizeRequest(AuthorizationFilterContext context)
        {
            context.HttpContext.Session.Clear();
            context.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Unauthorize.cshtml"
            };
        }
    }
}

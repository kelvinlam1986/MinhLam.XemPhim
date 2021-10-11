using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MinhLam.XemPhim.Web.Common;
using MinhLam.XemPhim.Web.Extensions;
using System.Globalization;
using System.Threading;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = (UserLogin)HttpContext.Session.GetObject<UserLogin>(CommonContants.USER_SESSION);
            if (session == null)
            {
                context.Result = new RedirectToRouteResult(
                    new { controller = "Login", action = "Index", Area = "Admin" });
            }
            base.OnActionExecuting(context);
        }

        // changing culture
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

            HttpContext.Session.SetString(CommonContants.CULTURE, ddlCulture);
            return Redirect(returnUrl);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
using Microsoft.AspNetCore.Http;
using MinhLam.XemPhim.Web.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MinhLam.XemPhim.Web.Middlewares
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Session.GetString(CommonContants.CULTURE);
            if (string.IsNullOrEmpty(cultureQuery) == false)
            {
                var culture = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            else
            {
                context.Session.SetString(CommonContants.CULTURE, "vi");
                var culture = new CultureInfo("vi");
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}

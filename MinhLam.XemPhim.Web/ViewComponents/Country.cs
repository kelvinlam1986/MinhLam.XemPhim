using Microsoft.AspNetCore.Mvc;
using MinhLam.XemPhim.Application.Web.Query;

namespace MinhLam.XemPhim.Web.ViewComponents
{
    public class Country : ViewComponent
    {
        private IHomePageMenuQuery query;

        public Country(IHomePageMenuQuery query)
        {
            this.query = query;
        }

        public IViewComponentResult Invoke()
        {
            var countries = this.query.GetCountryMenus();
            return View("Default", countries);
        }
    }
}

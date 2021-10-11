using Microsoft.AspNetCore.Mvc;
using MinhLam.XemPhim.Application.Web.Query;

namespace MinhLam.XemPhim.Web.ViewComponents
{
    public class Category : ViewComponent
    {
        private IHomePageMenuQuery query;

        public Category(IHomePageMenuQuery query)
        {
            this.query = query;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this.query.GetCategoryMenus();
            return View("Default", categories);
        }
    }
}

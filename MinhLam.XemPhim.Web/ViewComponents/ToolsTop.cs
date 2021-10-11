using Microsoft.AspNetCore.Mvc;

namespace MinhLam.XemPhim.Web.ViewComponents
{
    public class ToolsTop : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}

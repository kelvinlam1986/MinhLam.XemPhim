using Microsoft.AspNetCore.Mvc;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

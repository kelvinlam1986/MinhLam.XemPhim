using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhLam.Framework;
using MinhLam.XemPhim.Application.Web.Query;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;
using MinhLam.XemPhim.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhLam.XemPhim.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageQuery query;
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository repository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(
            IHomePageQuery query,
            ILogger<HomeController> logger)
        {
            this.query = query;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var slides = this.query.GetSlides();
            var newMovies = this.query.GetNewMovies(5);
            ViewBag.Slides = slides;
            ViewBag.NewMovies = newMovies;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

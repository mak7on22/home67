using Lesson67Tests.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson67Tests.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Response.StatusCode = 200;
            ControllerContext = new ControllerContext{ HttpContext = httpContext };
            ViewData["Message"] = "Добрый день, это тестовый текст на главной странице";
            var res = View("Main", new IndexViewModel());
            res.StatusCode = 200;
            return res;
        }


        public IActionResult Privacy()
        {
            ViewData["Policy"] = "Текст политики конфидециальности сайта.";
            return View("Privacy");
        }

        public IActionResult TestPage(int page)
        {
            ViewBag.PageIncrement = ++page;
            return View(new TestPageViewModel { Page = page });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
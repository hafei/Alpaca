using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alpaca.Models;
using Microsoft.Extensions.Logging;

namespace Alpaca.Controllers
{
    public class HomeController : Controller
    {
        private ILoggerFactory loggerFactory;
        public HomeController(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var url = Url.Action("About", "Home");
            var logger = loggerFactory.CreateLogger(nameof(HomeController));
            logger.LogInformation(url);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

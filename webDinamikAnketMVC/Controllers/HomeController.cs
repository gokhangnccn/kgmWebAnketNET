using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webDinamikAnketMVC.Models;

namespace webDinamikAnketMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Surveys");
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SilinmisAnketler()
        {
            return RedirectToAction("SilinmisAnketler", "Surveys");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

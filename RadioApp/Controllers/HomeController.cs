using Microsoft.AspNetCore.Mvc;
using RadioApp.Models;
using System.Diagnostics;

namespace RadioApp.Controllers
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
            List<RadioInfoViewModel> radioInfoViewModels = new List<RadioInfoViewModel>
            {
                new RadioInfoViewModel{Name ="ingrid"},
                new RadioInfoViewModel{Name ="tage"}
            };
          
            return View(radioInfoViewModels);
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
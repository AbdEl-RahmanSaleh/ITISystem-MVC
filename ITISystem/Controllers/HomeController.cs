using ITISystem.CustomActionFilter;
using ITISystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITISystem.Controllers
{
    //[ExceptionsFilter]
    [Authorize]
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [LogFilter]
        public IActionResult Index()
        {
            //int x = int.Parse("Ss");
            return View();
        }

        [LogFilter]
        public IActionResult Privacy()
        {
            //int x = int.Parse("Ss");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

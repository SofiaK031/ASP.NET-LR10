using LR10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(RegistrationModel registrationModel = null)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = "You were successfully registered for consultation!";
                return View();
            }
            else
            {
                return View(registrationModel);
            }
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

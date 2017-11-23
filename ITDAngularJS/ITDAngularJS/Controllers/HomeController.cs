using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITDAngularJS.Models;

namespace ITDAngularJS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Application()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

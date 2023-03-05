using irrigation_system_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using irrigation_system_webapp.Data;

namespace irrigation_system_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IrrigationAppContext _context;

        public HomeController(ILogger<HomeController> logger, IrrigationAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.temperature = 20000;
            return View();
        }
        public IActionResult Temperatures()
        {
            return View();
        }

        public IActionResult Record()
        {
            return View("Record", _context.Temperatures.ToList().OrderByDescending(t=>t.Date));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
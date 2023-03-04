using Microsoft.AspNetCore.Mvc;

namespace irrigation_system_webapp.Controllers
{
    public class TemperaturesController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Temperature = 20000;
            return View();
        }
    }
}

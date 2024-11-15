using Microsoft.AspNetCore.Mvc;

namespace KalenderApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

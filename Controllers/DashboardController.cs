using Microsoft.AspNetCore.Mvc;

namespace AIRBNB.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservations()
        {
            return View();
        }
    }
}

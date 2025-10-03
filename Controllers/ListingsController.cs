using Microsoft.AspNetCore.Mvc;

namespace AIRBNB.Controllers
{
    public class ListingsController : Controller
    {
        public IActionResult MyListings()
        {
            return View();
        }
    }
}

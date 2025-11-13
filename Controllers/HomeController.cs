using Microsoft.AspNetCore.Mvc;

namespace FoodMenu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

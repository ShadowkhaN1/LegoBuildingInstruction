using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
          

            return View();
        }
    }
}

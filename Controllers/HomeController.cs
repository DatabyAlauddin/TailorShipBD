using Microsoft.AspNetCore.Mvc;

namespace TylorShop.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

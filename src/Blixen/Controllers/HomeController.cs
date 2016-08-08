using Microsoft.AspNetCore.Mvc;

namespace Blixen.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MiddlewaresDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

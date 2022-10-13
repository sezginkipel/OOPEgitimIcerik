using Microsoft.AspNetCore.Mvc;

namespace WebKutuphane.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

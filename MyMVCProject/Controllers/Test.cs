using Microsoft.AspNetCore.Mvc;

namespace MyMVCProject.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyMVCProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

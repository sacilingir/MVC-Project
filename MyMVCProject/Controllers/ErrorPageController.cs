using Microsoft.AspNetCore.Mvc;

namespace MyMVCProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403;
            
            return View();
        }

        public IActionResult Page404(int code)
        {
            

            return View();
        }

        
    }
}

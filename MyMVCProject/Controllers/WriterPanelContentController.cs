using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyMVCProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public IActionResult MyContent()
        {
            var contentvalues = cm.GetListByWriter();
            return View(contentvalues);
        }
    }
}

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace MyMVCProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
		public IActionResult Index(Admin p)
		{
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if(adminuserinfo != null)
            {
                HttpContext.Session.SetString("xusername", adminuserinfo.AdminUserName);
				var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, adminuserinfo.AdminUserName)
					};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = false, // Tarayıcı kapandığında oturum sonlansın
				};

				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
				return RedirectToAction("Index", "AdminCategory");
				
			}
            else
            {
                return View();
            }
		}
        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writerinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if(writerinfo != null)
            {
                HttpContext.Session.SetString("xusername", writerinfo.WriterName);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, writerinfo.WriterName)
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false, // Tarayıcı kapandığında oturum sonlansın
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }




            return View();
        }

    }
}

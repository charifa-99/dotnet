
using Microsoft.AspNetCore.Mvc;

namespace ElearningPlatform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var uid = HttpContext.Session.GetInt32("uid");
            if (uid == null)
                return RedirectToAction("Login", "Account");
            
            return RedirectToAction("Index", "Dashboard");
        }
    }
}


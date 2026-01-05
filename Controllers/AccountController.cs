
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Data;
using ElearningPlatform.Models;

namespace ElearningPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)=>_db=db;

        public IActionResult Login()=>View();
        public IActionResult Register()=>View();

        [HttpPost]
        public IActionResult Register(string username,string password)
        {
            if(_db.AppUsers.Any(u=>u.Username==username))
            { ViewBag.Error="Existe déjà"; return View(); }

            _db.AppUsers.Add(new AppUser{
                Username=username,
                PasswordHash=AppUser.ComputeHash(password)
            });
            _db.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var hash=AppUser.ComputeHash(password);
            var u=_db.AppUsers.FirstOrDefault(x=>x.Username==username && x.PasswordHash==hash);
            if(u==null){ ViewBag.Error="Erreur"; return View(); }
            HttpContext.Session.SetInt32("uid",u.AppUserId);
            return RedirectToAction("Index","Dashboard");
        }

        public IActionResult Logout(){ HttpContext.Session.Clear(); return RedirectToAction("Login"); }
    }
}

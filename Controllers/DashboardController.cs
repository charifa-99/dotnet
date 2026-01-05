
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Data;
using ElearningPlatform.Models;
using System.Linq;

namespace ElearningPlatform.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db)=>_db=db;

        public IActionResult Index()
        {
            var uid=HttpContext.Session.GetInt32("uid");
            if(uid==null) return RedirectToAction("Login","Account");

            // Récupérer tous les cours avec leur progression
            var courses = _db.Courses.ToList();
            var progresses = _db.Progresses.Where(x => x.AppUserId == uid).ToList();
            
            var data = courses.Select(c => new DashboardViewModel
            { 
                Title = c.Title, 
                Percent = progresses.FirstOrDefault(p => p.CourseId == c.CourseId)?.Percentage ?? 0 
            }).ToList();

            return View(data);
        }
    }
}

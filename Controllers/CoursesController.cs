
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Data;
using System.Linq;

namespace ElearningPlatform.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CoursesController(ApplicationDbContext db)=>_db=db;
        
        public IActionResult Index()
        {
            var courses = _db.Courses.ToList();
            return View(courses);
        }
    }
}

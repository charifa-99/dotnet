
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Data;

namespace ElearningPlatform.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LessonsController(ApplicationDbContext db)=>_db=db;
        public IActionResult ByCourse(int id)=>View(_db.Lessons.Where(l=>l.CourseId==id).ToList());
    }
}

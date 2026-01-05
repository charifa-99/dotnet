
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Data;
using ElearningPlatform.Models;
using System.Globalization;

namespace ElearningPlatform.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuizController(ApplicationDbContext db)=>_db=db;

        public IActionResult Start(int courseId)
        {
            var uid=HttpContext.Session.GetInt32("uid");
            if(uid==null) return RedirectToAction("Login","Account");
            ViewBag.CourseId=courseId;
            return View(_db.QuizQuestions.Where(q=>q.CourseId==courseId).ToList());
        }

        [HttpPost]
        public IActionResult Submit(int courseId, Dictionary<int,string> answers)
        {
            var uid=HttpContext.Session.GetInt32("uid")!.Value;
            var qs=_db.QuizQuestions.Where(q=>q.CourseId==courseId).ToList();
            int score=0;
            foreach(var q in qs)
                if(answers.ContainsKey(q.QuizQuestionId)&&answers[q.QuizQuestionId]==q.Correct)
                    score+=100/qs.Count;

            bool passed=score>=50;
            _db.QuizResults.Add(new QuizResult{AppUserId=uid,CourseId=courseId,Score=score,Passed=passed});

            var p=_db.Progresses.FirstOrDefault(x=>x.AppUserId==uid && x.CourseId==courseId);
            if(p==null) _db.Progresses.Add(new Progress{AppUserId=uid,CourseId=courseId,Percentage=passed?100:score});
            else p.Percentage=passed?100:score;

            _db.SaveChanges();
            var user = _db.AppUsers.Find(uid);
            ViewBag.Score=score;
            ViewBag.Passed=passed;
            ViewBag.Course=_db.Courses.Find(courseId)!.Title;
            ViewBag.Username = user?.Username ?? "Utilisateur";
            ViewBag.Date = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("fr-FR"));
            return View("Result");
        }
    }
}


namespace ElearningPlatform.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = "";
        public string VideoUrl { get; set; } = "";
    }
}

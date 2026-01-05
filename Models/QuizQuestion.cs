
namespace ElearningPlatform.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public int CourseId { get; set; }
        public string Question { get; set; } = "";
        public string A { get; set; } = "";
        public string B { get; set; } = "";
        public string C { get; set; } = "";
        public string Correct { get; set; } = "";
    }
}

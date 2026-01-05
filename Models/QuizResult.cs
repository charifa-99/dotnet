
namespace ElearningPlatform.Models
{
    public class QuizResult
    {
        public int QuizResultId { get; set; }
        public int AppUserId { get; set; }
        public int CourseId { get; set; }
        public int Score { get; set; }
        public bool Passed { get; set; }
    }
}

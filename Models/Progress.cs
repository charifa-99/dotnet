
namespace ElearningPlatform.Models
{
    public class Progress
    {
        public int ProgressId { get; set; }
        public int AppUserId { get; set; }
        public int CourseId { get; set; }
        public int Percentage { get; set; }
    }
}

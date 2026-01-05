
using Microsoft.EntityFrameworkCore;
using ElearningPlatform.Models;

namespace ElearningPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
        public DbSet<QuizResult> QuizResults => Set<QuizResult>();
        public DbSet<Progress> Progresses => Set<Progress>();

        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Course>().HasData(
                new Course{CourseId=1,Title="Java",Description="Cours Java"},
                new Course{CourseId=2,Title="C#",Description="Cours C#"},
                new Course{CourseId=3,Title="Python",Description="Cours Python"},
                new Course{CourseId=4,Title="Web",Description="HTML CSS JS"}
            );

            m.Entity<Lesson>().HasData(
                new Lesson{LessonId=1,CourseId=1,Title="Intro Java",VideoUrl="https://www.youtube.com/embed/eIrMbAQSU34"},
                new Lesson{LessonId=2,CourseId=2,Title="Intro C#",VideoUrl="https://www.youtube.com/embed/GhQdlIFylQ8"},
                new Lesson{LessonId=3,CourseId=3,Title="Intro Python",VideoUrl="https://www.youtube.com/embed/_uQrJ0TkZlc"},
                new Lesson{LessonId=4,CourseId=4,Title="Intro Web",VideoUrl="https://www.youtube.com/embed/UB1O30fR-EE"}
            );

            int id=1;
            void Q(int c,string q,string a,string b,string cc,string ok){
                m.Entity<QuizQuestion>().HasData(
                    new QuizQuestion{QuizQuestionId=id++,CourseId=c,Question=q,A=a,B=b,C=cc,Correct=ok});
            }
            for(int c=1;c<=4;c++){
                Q(c,"Q1?","A","B","C","A");
                Q(c,"Q2?","A","B","C","B");
                Q(c,"Q3?","A","B","C","C");
                Q(c,"Q4?","A","B","C","A");
                Q(c,"Q5?","A","B","C","B");
                Q(c,"Q6?","A","B","C","C");
            }
        }
    }
}

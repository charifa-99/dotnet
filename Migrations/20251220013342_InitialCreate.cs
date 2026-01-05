using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    VideoUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    ProgressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Percentage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.ProgressId);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    QuizQuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    A = table.Column<string>(type: "TEXT", nullable: false),
                    B = table.Column<string>(type: "TEXT", nullable: false),
                    C = table.Column<string>(type: "TEXT", nullable: false),
                    Correct = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.QuizQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    QuizResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Passed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResults", x => x.QuizResultId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Cours Java", "Java" },
                    { 2, "Cours C#", "C#" },
                    { 3, "Cours Python", "Python" },
                    { 4, "HTML CSS JS", "Web" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "CourseId", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 1, "Intro Java", "https://www.youtube.com/embed/eIrMbAQSU34" },
                    { 2, 2, "Intro C#", "https://www.youtube.com/embed/GhQdlIFylQ8" },
                    { 3, 3, "Intro Python", "https://www.youtube.com/embed/_uQrJ0TkZlc" },
                    { 4, 4, "Intro Web", "https://www.youtube.com/embed/UB1O30fR-EE" }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "QuizQuestionId", "A", "B", "C", "Correct", "CourseId", "Question" },
                values: new object[,]
                {
                    { 1, "A", "B", "C", "A", 1, "Q1?" },
                    { 2, "A", "B", "C", "B", 1, "Q2?" },
                    { 3, "A", "B", "C", "C", 1, "Q3?" },
                    { 4, "A", "B", "C", "A", 1, "Q4?" },
                    { 5, "A", "B", "C", "B", 1, "Q5?" },
                    { 6, "A", "B", "C", "C", 1, "Q6?" },
                    { 7, "A", "B", "C", "A", 2, "Q1?" },
                    { 8, "A", "B", "C", "B", 2, "Q2?" },
                    { 9, "A", "B", "C", "C", 2, "Q3?" },
                    { 10, "A", "B", "C", "A", 2, "Q4?" },
                    { 11, "A", "B", "C", "B", 2, "Q5?" },
                    { 12, "A", "B", "C", "C", 2, "Q6?" },
                    { 13, "A", "B", "C", "A", 3, "Q1?" },
                    { 14, "A", "B", "C", "B", 3, "Q2?" },
                    { 15, "A", "B", "C", "C", 3, "Q3?" },
                    { 16, "A", "B", "C", "A", 3, "Q4?" },
                    { 17, "A", "B", "C", "B", 3, "Q5?" },
                    { 18, "A", "B", "C", "C", 3, "Q6?" },
                    { 19, "A", "B", "C", "A", 4, "Q1?" },
                    { 20, "A", "B", "C", "B", 4, "Q2?" },
                    { 21, "A", "B", "C", "C", 4, "Q3?" },
                    { 22, "A", "B", "C", "A", 4, "Q4?" },
                    { 23, "A", "B", "C", "B", 4, "Q5?" },
                    { 24, "A", "B", "C", "C", 4, "Q6?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "QuizResults");
        }
    }
}

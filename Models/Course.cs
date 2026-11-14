namespace RU_ASP_Semester_Project.Models
{
    public class Course
    {
        public required int CourseId { get; set; }
        public required string CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public required int ProgramId { get; set; }
        public Program? Program { get; set; }
    }
}

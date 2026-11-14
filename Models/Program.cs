using System.ComponentModel.DataAnnotations;

namespace RU_ASP_Semester_Project.Models
{
    public class Program
    {
        [Key]
        public required int ProgramId { get; set; }
        public required string ProgramName { get; set; }
        public string? ProgramDescription { get; set; }
        public required int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}

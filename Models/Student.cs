using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RU_ASP_Semester_Project.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; } = string.Empty;
        //generic dummy test
        [ForeignKey("nameof(StudentId)")]
        public IdentityUser? User { get; set; }

        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? ProgramId { get; set; }
        public Program? Program { get; set; }

    }
}

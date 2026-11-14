using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RU_ASP_Semester_Project.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; } = string.Empty;
        //generic dummy test
        [ForeignKey("nameof(EmployeeId)")]
        public IdentityUser? User { get; set; }

        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? JobTitle { get; set; }
        public string? Program { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}

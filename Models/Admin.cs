using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RU_ASP_Semester_Project.Models
{
    public class Admin
    {
        //generic dummy test
        [Key]
        public string AdminId { get; set; } = string.Empty;
        [ForeignKey("nameof(AdminId)")]
        public IdentityUser? User { get; set; }

        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? JobTitle { get; set; }
        public string? DepartmentId { get; set; }
    }
}

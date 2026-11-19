using System.ComponentModel.DataAnnotations;

namespace RU_ASP_Semester_Project.Models
{
    public class Department
    {
        //Department info
        public required int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }

        [StringLength(250)]
        public string? DepartmentDescription { get; set; }
        [StringLength(100)]
        public string? OfficeLocation { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        //Event Organized by department
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

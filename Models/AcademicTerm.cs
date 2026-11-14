namespace RU_ASP_Semester_Project.Models
{
    public class AcademicTerm
    {
        public required int AcademicTermId { get; set; }
        public required string AcademicTermName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}

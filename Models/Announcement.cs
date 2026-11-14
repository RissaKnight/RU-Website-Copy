namespace RU_ASP_Semester_Project.Models
{
    public class Announcement
    {
        public string? AnnouncementId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public required string Audience { get; set; } 
        //Students Employees All
        public bool IsPublished { get; set; }
    }
}

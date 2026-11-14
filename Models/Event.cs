namespace RU_ASP_Semester_Project.Models
{
    public class Event
    {
        public string? EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPublished { get; set; }
    }
}

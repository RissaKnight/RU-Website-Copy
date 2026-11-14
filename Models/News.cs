namespace RU_ASP_Semester_Project.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool isPublished { get; set; }
    }
}

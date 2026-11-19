namespace RU_ASP_Semester_Project.Models
{
    public class Location
    {
        //Location info
        public required string LocationId { get; set; }
        public string? LocationName { get; set; }

        //Location Address
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        //Online
        public string? OnlineMeetingUrl { get; set; }

        //Assigned Location Events
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

namespace RU_ASP_Semester_Project.Models
{
    public class Event
    {
        //Event info
        public required string EventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }

        //Event timing info
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }

        //Event Image info
        public string? EventImagePath { get; set; }
        public string? EventImageDisplayName { get; set; }

        //Category and tags
        public string? Category { get; set; }
        public string? Tags { get; set; }

        //Event location info
        public required string LocationId { get; set; }
        public Location? EventLocation { get; set; }
        public string? RoomNumber { get; set; }

        //Department 
        public int? DepartmentId { get; set; }
        public Department? EventDepartment { get; set; }

        //Audience
        public string? Audience { get; set; }

        //External info
        public string? ExternalWebsite { get; set; }

        // Event cost
        public decimal EventCost { get; set; }

        //Submit info
        public string? SubmittedBy { get; set; }
        public DateTime? SubmittedDate { get; set; }

        //Admin Approval
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        //Publish info
        public DateTime? PublishedDate { get; set; }

        //Pending(Default), Published, Rejected
        public string? Status { get; set; } = "Pending";

        //Scheduled(Default), Canceled, Postponed, Moved Online
        public string EventStatus { get; set; } = "Scheduled";

        public bool IsPublished { get; set; }
    }
}

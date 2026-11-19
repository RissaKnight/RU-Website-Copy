namespace RU_ASP_Semester_Project.Models
{
    public class Announcement
    {
        //Announcement info
        public string? AnnouncementId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        //Attchment info
        public string? AttachmentPath { get; set; }
        public string? AttachmentFileName { get; set; }
        //Announcement display info
        public string? ImagePath { get; set; }
        public string? AnnouncementImageDisplayName { get; set; }

        //Submit info
        public string? SubmittedBy { get; set; }
        public DateTime? SubmittedDate { get; set; }

        //Admin Approval
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        //Publish info
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        //public required string Audience { get; set; } 
        //can get rid of audience 


        //Pending(Default), Approved, Rejected
        public string Status { get; set; } = "Pending"; 

        //Students Employees All
        public bool IsPublished { get; set; }
    }
}

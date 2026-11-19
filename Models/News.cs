namespace RU_ASP_Semester_Project.Models
{
    public class News
    {
        //News info
        public required int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }

        // News image info
        public string? NewsImagePath { get; set; }
        public string? NewsImageDisplayName { get; set; }

        //Submit info
        //login credentials for submit
        public string? SubmittedBy { get; set; }
        public DateTime? SubmittedDate { get; set; }

        //Admin Approval
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        //Publish info
        public DateTime? PublishedDate { get; set; }

        //Pending(Default), Approved, Rejected
        public string Status { get; set; } = "Pending";

        public bool IsPublished { get; set; }
    }
}

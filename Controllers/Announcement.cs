
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Models;
using RU_ASP_Semester_Project.Data;

namespace RU_ASP_Semester_Project.Controllers
{
    [Authorize]
    public class AnnouncementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // VIEW ALL PUBLISHED ANNOUNCEMENTS
        public async Task<IActionResult> Index()
        {
            var announcements = await _context.Announcements
                .Where(a => a.IsPublished && a.Status == "Approved")
                .OrderByDescending(a => a.PublishedDate)
                .ToListAsync();

            return View(announcements);
        }

        // DISPLAY ANNOUNCEMENT SUBMISSION FORM
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // PROCESS SUBMITTED ANNOUNCEMENT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                // Generate announcement ID
                announcement.AnnouncementId = Guid.NewGuid().ToString();

                // Submission information
                announcement.SubmittedBy = User.Identity?.Name;
                announcement.SubmittedDate = DateTime.Now;

                // Approval and publishing information
                announcement.Status = "Pending";
                announcement.IsPublished = false;
                announcement.ApprovedBy = null;
                announcement.ApprovedDate = null;
                announcement.PublishedDate = null;

                // Save announcement
                _context.Announcements.Add(announcement);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(announcement);
        }
    }
}

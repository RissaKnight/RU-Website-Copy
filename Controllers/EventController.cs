
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Models;
using RU_ASP_Semester_Project.Data;

namespace RU_ASP_Semester_Project.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // VIEW ALL PUBLISHED EVENTS
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .Include(e => e.EventLocation)
                .Include(e => e.EventDepartment)
                .Where(e => e.IsPublished && e.Status == "Published")
                .OrderBy(e => e.StartTime)
                .ToListAsync();

            return View(events);
        }
    }
}

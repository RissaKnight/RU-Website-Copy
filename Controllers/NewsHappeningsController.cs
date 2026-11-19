
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Data;
using RU_ASP_Semester_Project.Models;

namespace RU_ASP_Semester_Project.Controllers
{
    [Authorize]
    public class NewsHappeningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsHappeningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Student News & Happenings page
        public async Task<IActionResult> Index()
        {
            var news = await _context.News
                .Where(n => n.IsPublished && n.Status == "Approved")
                .OrderByDescending(n => n.PublishedDate)
                .ToListAsync();

            return View(news);
        }

        // Display the submit news form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Process submitted news
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.SubmittedBy = User.Identity?.Name;
                news.SubmittedDate = DateTime.Now;
                news.Status = "Pending";
                news.IsPublished = false;

                _context.News.Add(news);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }

        // View one news article
        public async Task<IActionResult> Details(int id)
        {
            var news = await _context.News
                .FirstOrDefaultAsync(n =>
                    n.NewsId == id &&
                    n.IsPublished &&
                    n.Status == "Approved");

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Models;
using RU_ASP_Semester_Project.Data;

namespace RU_ASP_Semester_Project.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // VIEW ALL PUBLISHED BLOGS
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs
                .Where(b => b.isPublished)
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();

            return View(blogs);
        }

        // VIEW FULL BLOG POST
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _context.Blogs
                .FirstOrDefaultAsync(b =>
                    b.BlogId == id && b.isPublished);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}

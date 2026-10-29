using Microsoft.AspNetCore.Mvc;

namespace RU_ASP_Semester_Project.Areas.Public.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

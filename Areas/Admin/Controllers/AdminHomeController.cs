using Microsoft.AspNetCore.Mvc;

namespace RU_ASP_Semester_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Home/Dashboard/Index.cshtml");
        }
    }
}
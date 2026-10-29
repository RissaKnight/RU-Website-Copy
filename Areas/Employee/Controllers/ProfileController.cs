using Microsoft.AspNetCore.Mvc;

namespace RU_ASP_Semester_Project.Areas.Employee.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

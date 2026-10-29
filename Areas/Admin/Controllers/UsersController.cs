using Microsoft.AspNetCore.Mvc;

namespace RU_ASP_Semester_Project.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

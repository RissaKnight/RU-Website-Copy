using Microsoft.AspNetCore.Mvc;

namespace RU_ASP_Semester_Project.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Employee/Views/Home/Dashboard/Index.cshtml");
        }
    }
}

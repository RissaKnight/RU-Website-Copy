using Microsoft.AspNetCore.Mvc;
using RU_ASP_Semester_Project.Models;
using System.Diagnostics;

namespace RU_ASP_Semester_Project.Controllers
{
    public class HomeController : Controller
    {
        //PUBLIC HOME
        public IActionResult Index()
        {
            //CHECK IF USER LOG IN
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {

                //ADMIN DASH
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(
                        "Index", "AdminHome",
                        new { area = "Admin" });
                }
                //EMPLOYEE DASH
                if (User.IsInRole("Employee"))
                {
                    return RedirectToAction(
                        "Index", "EmployeeHome",
                        new { area = "Employee" });
                }
                //STUDENT DASH
                if (User.IsInRole("Student"))
                {
                    return RedirectToAction(
                        "Index", "StudentHome",
                        new { area = "Student" });
                }
            }
            //IF NO LOG IN PUBLIC
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //ERROR PAGE
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

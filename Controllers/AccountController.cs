using Microsoft.AspNetCore.Mvc;
using RU_ASP_Semester_Project.Models;
using System.Diagnostics;

namespace RU_ASP_Semester_Project.Controllers 
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RU_ASP_Semester_Project.Models;
using RU_ASP_Semester_Project.Data;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Claims;

namespace RU_ASP_Semester_Project.Controllers 
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ApplicationDbContext _context;
        //connect login manage and database
        public AccountController(SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        // POST /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //check if valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //check user and pass
            var result = await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // get logged in user info
                var user = await _signInManager.UserManager.FindByNameAsync(model.Username);
                //check if user found
                if (user == null)
                {
                    ModelState.AddModelError("", "Unable to find user information.");
                    return View(model);
                }

                //ADMIN
                //check if user is admin
                if (await _signInManager.UserManager.IsInRoleAsync(user, "Admin"))
                {
                    //retrieve admin info from database by id
                    var admin = await _context.Admins
                        .FirstOrDefaultAsync(a => a.AdminId == user.Id);
                    //check if admin info found
                    if (admin == null)
                    {
                        ModelState.AddModelError("", "Unable to find admin information.");
                        return View(model);
                    }
                    //store admin info in session
                    var claims = new List<Claim>
                    {
                        new Claim("FirstName", admin.FirstName),
                        new Claim("LastName", admin.LastName)
                    };
                    //update the login cookie with the user name claims
                    await _signInManager.SignInWithClaimsAsync(user, model.RememberMe, claims);

                    //return to admin dash
                    return RedirectToAction("Index", "AdminHome",
                        new { area = "Admin" });

                }
                //EMPLOYEE
                //check user is employee
                if (await _signInManager.UserManager.IsInRoleAsync(user, "Employee"))
                {
                    //retrieve employee info from database by id
                    var employee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.EmployeeId == user.Id);

                    //check if employee info found
                    if (employee == null)
                    {
                        ModelState.AddModelError("", "Unable to find employee information.");
                        return View(model);
                    }
                    //store admin info in session
                    var claims = new List<Claim>
                    {
                        new Claim("FirstName", employee.FirstName),
                        new Claim("LastName", employee.LastName)
                    };
                    //update the login cookie with the user name claims
                    await _signInManager.SignInWithClaimsAsync(user, model.RememberMe, claims);


                    //return to employee dash
                    return RedirectToAction("Index", "EmployeeHome",
                        new { area = "Employee" });
                }
                //STUDENT
                //check if user is student
                if (await _signInManager.UserManager.IsInRoleAsync(user, "Student"))
                {
                    //retreive student info from database by id
                    var student = await _context.Students
                        .FirstOrDefaultAsync(s => s.StudentId == user.Id);

                    //check if student info found
                    if (student == null)
                    {
                        ModelState.AddModelError("", "Unable to find student information.");
                        return View(model);
                    }
                    //store admin info in session
                    var claims = new List<Claim>
                    {
                        new Claim("FirstName", student.FirstName),
                        new Claim("LastName", student.LastName)
                    };
                    //update the login cookie with the user name claims
                    await _signInManager.SignInWithClaimsAsync(user, model.RememberMe, claims);


                    //return to student dash
                    return RedirectToAction("Index", "StudentHome",
                        new { area = "Student" });
                }

                // check if no match role found
                ModelState.AddModelError("", "User doesn't have an assigned role.");
                await _signInManager.SignOutAsync();
                return View(model);

            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }
        }
        // POST /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //if logout take to main public home page
            return RedirectToAction("Index", "Home");
        }

    }
}

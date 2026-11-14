using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Models;

namespace RU_ASP_Semester_Project.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context,
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            // Ensure the database is created
            await context.Database.MigrateAsync();

            // Check if the roles exist makes new if they don't
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (!await roleManager.RoleExistsAsync("Student"))
            {
                await roleManager.CreateAsync(new IdentityRole("Student"));
            }
            // Check if the admin user exists
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");


            if (adminUser == null)
            {
                // Create the admin user
                adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                //create with temp test pass
                var result = await userManager.CreateAsync(adminUser, "Admin123!");

                //stop if creation failed
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create admin user.");
                }
            }

            // assign role to admin if doesn't exist
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            //create admin profile if doesn't exist
            if (!context.Admins.Any(a => a.AdminId == adminUser.Id))
            { 
                context.Admins.Add(new Admin
                {
                    AdminId = adminUser.Id,
                    FirstName = "Test",
                    LastName = "Admin",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = adminUser.Email,
                    PhoneNumber = "123-456-7890",
                    JobTitle = "Administrator"
                });
            }
            //employee creation
            var employeeUser = await userManager.FindByEmailAsync("employee@example.com");

            if (employeeUser == null)
            {
                // Create the employee user
                employeeUser = new IdentityUser
                {
                    UserName = "employee",
                    Email = "employee@example.com",
                    EmailConfirmed = true
                };
                //create with temp test pass
                var result = await userManager.CreateAsync(employeeUser, "Employee123!");

                //stop if creation failed
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create employee user.");
                }
            }

            // assign role to employee if doesn't exist
            if (!await userManager.IsInRoleAsync(employeeUser, "Employee"))
            {
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            //create employee profile if doesn't exist
            if (!context.Employees.Any(e => e.EmployeeId == employeeUser.Id))
            { 
                context.Employees.Add(new Employee
                {
                    EmployeeId = employeeUser.Id,
                    FirstName = "Test",
                    LastName = "Employee",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = employeeUser.Email,
                    PhoneNumber = "123-456-7890",
                    JobTitle = "Employee"
                });
            }

            //student creation
            var studentUser = await userManager.FindByEmailAsync("student@example.com");

            if(studentUser == null)
            {
                // Create the student user
                studentUser = new IdentityUser
                {
                    UserName = "student",
                    Email = "student@example.com",
                    EmailConfirmed = true
                };
                //create with temp test pass
                var result = await userManager.CreateAsync(studentUser, "Student123!");

                //stop if creation failed
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create student user.");
                }
            }

            // assign role to student if doesn't exist
            if (!await userManager.IsInRoleAsync(studentUser, "Student"))
            {
                await userManager.AddToRoleAsync(studentUser, "Student");
            }

            //create student profile if doesn't exist
            if (!context.Students.Any(s => s.StudentId == studentUser.Id))
            { 
                context.Students.Add(new Student
                {
                    StudentId = studentUser.Id,
                    FirstName = "Test",
                    LastName = "Student",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = studentUser.Email,
                    PhoneNumber = "123-456-7890",
                    ProgramId = null
                });
            }

            //save changes to db
            await context.SaveChangesAsync();


        }
    }
}

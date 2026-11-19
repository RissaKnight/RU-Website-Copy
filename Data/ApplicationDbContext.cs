
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RU_ASP_Semester_Project.Models;
using AcademicProgram = RU_ASP_Semester_Project.Models.Program;

namespace RU_ASP_Semester_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add db sets for models
        public DbSet<AcademicTerm> AcademicTerms { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<AcademicProgram> Programs { get; set; }
        public DbSet<Student> Students { get; set; }

        // Create relationships between models
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AcademicProgram>().HasKey(p => p.ProgramId);

            //Set LocationKey
            builder.Entity<Location>().HasKey(l => l.LocationId);
            //Prevent Dupe Location
            builder.Entity<Location>()
                .HasIndex(l => l.LocationName)
                .IsUnique();

            //Connect Event to location
            builder.Entity<Event>()
                .HasOne<Location>(e => e.EventLocation)
                .WithMany(l => l.Events)
                .HasForeignKey(e => e.LocationId);

            //Connect Event to Department
            builder.Entity<Event>()
                .HasOne<Department>(e => e.EventDepartment)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.DepartmentId);

            //Users
            builder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<Admin>(a => a.AdminId);

            builder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.EmployeeId);

            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.StudentId);
        }
    }
}

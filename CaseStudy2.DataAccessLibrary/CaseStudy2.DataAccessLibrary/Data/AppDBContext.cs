using CaseStudy2.DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskList> Tasks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}

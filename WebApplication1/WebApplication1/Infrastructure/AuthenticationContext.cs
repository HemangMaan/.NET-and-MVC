using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class AuthenticationContext: DbContext
    {

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>(entity => entity.HasKey("UserId", "RoleId"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }

    //PM> [package manager console]
    //PM> Add-Migration InitialCreate -context AuthenticationContext
    //Build succeeded
    //creates a migration file for converting the classes to db tables
    //PM> Update-Database -context AuthenticationContext
    //creates the database, tables and all the columns in the tables

}

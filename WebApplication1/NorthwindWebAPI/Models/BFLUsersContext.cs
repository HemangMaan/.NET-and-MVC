using Microsoft.EntityFrameworkCore;

namespace NorthwindWebAPI.Models
{
    public class BFLUsersContext : DbContext
    {
        public BFLUsersContext(DbContextOptions<BFLUsersContext> options): base(options)
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

}

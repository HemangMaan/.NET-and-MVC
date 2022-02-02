using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class NorthWindContext: DbContext
    {
        public NorthWindContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\northwind.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public DbSet<Customer> Customers { get; set; }

    }
}

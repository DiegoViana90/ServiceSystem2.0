using ServiceSystem2.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceSystem2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

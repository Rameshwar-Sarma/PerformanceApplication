using Microsoft.EntityFrameworkCore;
using PerformanceTipsAssignment.Models;

namespace PerformanceTipsAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

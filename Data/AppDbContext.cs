using Microsoft.EntityFrameworkCore;
using PhilosophersApi.Models;

namespace PhilosophersApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Quote> Quotes { get; set; }
    }
}

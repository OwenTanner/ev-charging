using Microsoft.EntityFrameworkCore;

namespace EvChargingApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        
        public DbSet<ApplicationData> Applications { get; set; } = null!;

    }
}

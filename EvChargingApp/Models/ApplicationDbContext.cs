using Microsoft.EntityFrameworkCore;

namespace EvChargingApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Define your database table(s)
        public DbSet<ApplicationData> Applications { get; set; } = null!;

    }
}

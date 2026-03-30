using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Tracker.Models;

namespace Vehicle_Service_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
    }
}

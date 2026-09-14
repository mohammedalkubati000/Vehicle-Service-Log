using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Log.Models;

namespace Vehicle_Service_Log.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ServiceLog> ServiceLogs { get; set; }  
    }
}

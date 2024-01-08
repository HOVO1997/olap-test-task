using Microsoft.EntityFrameworkCore;
using olap_api.Models;

namespace olap_api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Indicator> Indicators { get; set; }

        public DbSet<DataPoint> DataPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataPointConfiguration());
        }
    }
}

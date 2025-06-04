using HiveService.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace HiveService.API.Infrastructure
{
    public class HiveDbContext : DbContext
    {
        public HiveDbContext(DbContextOptions<HiveDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hive> Hives => Set<Hive>();
    }
}

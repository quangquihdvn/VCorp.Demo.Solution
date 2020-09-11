using Microsoft.EntityFrameworkCore;
using VCorp.Demo.Data.Configurations;
using VCorp.Demo.Data.Entities;

namespace VCorp.Demo.Data.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsContentConfigution());
            modelBuilder.ApplyConfiguration(new NewsExtensionConfiguration());
            modelBuilder.ApplyConfiguration(new ZoneConfiguration());
        }

        public DbSet<NewsContent> NewsContents { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<NewsExtension> NewsExtensions { get; set; }
    }
}

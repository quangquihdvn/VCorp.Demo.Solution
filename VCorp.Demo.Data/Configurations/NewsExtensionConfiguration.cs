using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VCorp.Demo.Data.Entities;

namespace VCorp.Demo.Data.Configurations
{
    public class NewsExtensionConfiguration : IEntityTypeConfiguration<NewsExtension>
    {
        public void Configure(EntityTypeBuilder<NewsExtension> builder)
        {
            builder.ToTable("NewsExtension");

            builder.HasKey(x => new { x.NewsId, x.Type });
            builder.Property(x => x.NewsId).IsRequired().HasColumnType("bigint");

            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(t => t.NewsContent)
                .WithMany(pc => pc.NewsExtensions)
                .HasForeignKey(pc => pc.NewsId);
        }
    }
}

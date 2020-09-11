using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VCorp.Demo.Data.Entities;

namespace VCorp.Demo.Data.Configurations
{
    public class NewsContentConfigution : IEntityTypeConfiguration<NewsContent>
    {
        public void Configure(EntityTypeBuilder<NewsContent> builder)
        {
            builder.ToTable("NewsContent");

            builder.HasKey(x => x.NewsId);
            builder.Property(x => x.NewsId).IsRequired().HasColumnType("bigint");

            builder.Property(x => x.Title).HasMaxLength(250);
            builder.Property(x => x.Avatar).HasMaxLength(500);
            builder.Property(x => x.Avatar2).HasMaxLength(500);
            builder.Property(x => x.Avatar3).HasMaxLength(500);
            builder.Property(x => x.Avatar4).HasMaxLength(500);
            builder.Property(x => x.Avatar5).HasMaxLength(500);

            builder.Property(x => x.PublishedDate).IsRequired();
            builder.Property(x => x.Source).HasMaxLength(100);
            builder.Property(x => x.Author).HasMaxLength(500);
            builder.Property(x => x.TagPrimary).HasMaxLength(500);
            builder.Property(x => x.Url).HasMaxLength(500);
            builder.Property(x => x.OriginalId).HasColumnType("bigint");
            builder.Property(x => x.TagItem).HasMaxLength(1000);
            builder.Property(x => x.SubTitle).HasMaxLength(250);
            builder.Property(x => x.InitSapo).HasMaxLength(500);
            builder.Property(x => x.OriginalUrl).HasMaxLength(500);
            builder.Property(x => x.AvatarDesc).HasMaxLength(500);
            builder.Property(x => x.AdStoreUrl).HasMaxLength(500);
            builder.Property(x => x.SourceUrl).HasMaxLength(500);
            builder.Property(x => x.ParentNewsId).HasColumnType("bigint");

            builder.HasOne(t => t.Zone)
                .WithMany(pc => pc.NewsContents)
                .HasForeignKey(pc => pc.ZoneId);
        }
    }
}

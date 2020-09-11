using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using VCorp.Demo.Data.Entities;

namespace VCorp.Demo.Data.Configurations
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zone");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ShortUrl).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Invisibled).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Domain).HasMaxLength(200);
            builder.Property(x => x.AvatarCover).HasMaxLength(500);

        }
    }
}

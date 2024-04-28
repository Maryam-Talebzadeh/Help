using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class ServiceConfiguration : IEntityTypeConfiguration<HelpService>
    {
        public void Configure(EntityTypeBuilder<HelpService> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Tags).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            #region Relations

            builder.HasMany(s => s.Categories)
              .WithOne(c => c.HelpService);

            builder.HasMany(s => s.Skills)
                .WithOne(s => s.HelpService)
                .HasForeignKey(s => s.ServiceId);

            builder.HasOne(s => s.Picture)
                .WithOne(p => p.HelpService)
                .HasForeignKey<ServicePicture>(p => p.ServiceId);

            builder.HasMany(s => s.HelpRequests)
               .WithOne(s => s.HelpService)
               .HasForeignKey(s => s.ServiceId);

            #endregion

        }
    }
}

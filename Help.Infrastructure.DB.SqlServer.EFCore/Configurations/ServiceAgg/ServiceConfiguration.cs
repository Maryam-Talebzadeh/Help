using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Tags).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            #region Relations

            builder.HasMany(s => s.Categories)
              .WithOne(c => c.Service);

            builder.HasMany(s => s.Skills)
                .WithOne(s => s.Service)
                .HasForeignKey(s => s.ServiceId);

            builder.HasOne(s => s.Picture)
                .WithOne(p => p.Service)
                .HasForeignKey<ServicePicture>(p => p.ServiceId);

            builder.HasMany(s => s.HelpRequests)
               .WithOne(s => s.Service)
               .HasForeignKey(s => s.ServiceId);

            #endregion

        }
    }
}

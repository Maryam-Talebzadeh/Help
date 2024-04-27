using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class ServicePictureConfiguration : IEntityTypeConfiguration<ServicePicture>
    {
        public void Configure(EntityTypeBuilder<ServicePicture> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(100).IsRequired();
        }
    }
}

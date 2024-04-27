using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class HelpRequestPictureConfiguration : IEntityTypeConfiguration<HelpRequestPicture>
    {
        public void Configure(EntityTypeBuilder<HelpRequestPicture> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(100).IsRequired();
        }
    }
}

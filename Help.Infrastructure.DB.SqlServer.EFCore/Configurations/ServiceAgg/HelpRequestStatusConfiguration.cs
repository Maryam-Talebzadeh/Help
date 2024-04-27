using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class HelpRequestStatusConfiguration : IEntityTypeConfiguration<HelpRequestStatus>
    {
        public void Configure(EntityTypeBuilder<HelpRequestStatus> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}

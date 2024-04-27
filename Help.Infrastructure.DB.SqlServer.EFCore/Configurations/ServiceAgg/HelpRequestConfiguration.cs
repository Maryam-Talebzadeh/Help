using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class HelpRequestConfiguration : IEntityTypeConfiguration<HelpRequest>
    {
        public void Configure(EntityTypeBuilder<HelpRequest> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            #region Relations

            builder.HasOne(h => h.Status)
              .WithMany(s => s.HelpRequests)
              .HasForeignKey(h => h.StatusId);

            builder.HasOne(h => h.Service)
            .WithMany(s => s.HelpRequests)
            .HasForeignKey(h => h.ServiceId);

            builder.HasMany(h => h.Pictures)
              .WithOne(p => p.HelpRequest)
              .HasForeignKey(p => p.HelpRequestId);

            builder.HasMany(h => h.Proposals)
             .WithOne(p => p.HelpRequest)
             .HasForeignKey(p => p.HelpRequestId).OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}

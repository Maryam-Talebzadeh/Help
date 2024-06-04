using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class HelpRequestConfiguration : IEntityTypeConfiguration<HelpRequest>
    {
        public void Configure(EntityTypeBuilder<HelpRequest> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations


            builder.HasOne(h => h.Status)
              .WithMany(s => s.HelpRequests)
              .HasForeignKey(h => h.StatusId);

            builder.HasOne(h => h.HelpService)
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

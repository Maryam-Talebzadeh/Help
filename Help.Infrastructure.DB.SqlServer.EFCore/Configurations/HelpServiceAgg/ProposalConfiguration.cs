using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}

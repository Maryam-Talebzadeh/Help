using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Message).HasMaxLength(1000).IsRequired();

            #region Relations

            builder.HasOne(c => c.HelpRequest)
              .WithMany(h => h.Comments)
              .HasForeignKey(c => c.HelpRequestId);

            #endregion
        }
    }
}

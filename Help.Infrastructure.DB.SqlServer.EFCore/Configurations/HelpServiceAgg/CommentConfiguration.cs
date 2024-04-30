using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations

            builder.HasOne(c => c.HelpRequest)
              .WithMany(h => h.Comments)
              .HasForeignKey(c => c.HelpRequestId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Parent)
             .WithMany(h => h.Children)
             .HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}

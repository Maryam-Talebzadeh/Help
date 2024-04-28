using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);

            #region Relation

            builder.HasMany(c => c.Services)
             .WithOne(sc => sc.Category).OnDelete(deleteBehavior:DeleteBehavior.NoAction);

            builder.HasOne(c => c.Parent)
           .WithMany(sc => sc.Children).OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion
        }
    }
}

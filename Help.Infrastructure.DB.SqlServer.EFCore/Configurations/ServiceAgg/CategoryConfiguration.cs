

using Help.Domain.Core.ServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg
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
        

            #endregion
        }
    }
}

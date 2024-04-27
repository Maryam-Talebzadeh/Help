using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class CustomerRoleConfiguration : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();

            #region Relations

            builder.HasMany(cr => cr.Comments)
               .WithOne(c => c.CustomerRole)
               .HasForeignKey(c => c.CustomerRoleId);

            #endregion
        }
    }
}

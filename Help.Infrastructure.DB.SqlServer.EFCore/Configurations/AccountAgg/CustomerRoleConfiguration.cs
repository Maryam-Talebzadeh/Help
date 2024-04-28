using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class CustomerRoleConfiguration : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {

            #region Relations

            builder.HasMany(cr => cr.Comments)
               .WithOne(c => c.CustomerRole)
               .HasForeignKey(c => c.CustomerRoleId);

            builder.HasOne(cr => cr.Role)
              .WithMany(r => r.CustomerRoles)
              .HasForeignKey(cr => cr.RoleId);

            #endregion
        }
    }
}

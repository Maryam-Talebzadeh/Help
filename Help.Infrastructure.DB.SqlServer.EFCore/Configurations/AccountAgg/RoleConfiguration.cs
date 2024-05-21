using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Title).HasMaxLength(100);

            #region Seed Data

            Role role1 = new Role("مدیر سیستم");
            role1.Id = 1;

            builder.HasData(role1);

            Role role2 = new Role("کاربر عادی");
            role2.Id = 2;

            builder.HasData(role2);

            #endregion
        }


    }
}

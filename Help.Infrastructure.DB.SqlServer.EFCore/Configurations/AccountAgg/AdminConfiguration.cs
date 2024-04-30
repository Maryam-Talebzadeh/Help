using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class AdminConfiguration :IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
    {
            builder.Property(c => c.FullName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.UserName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}

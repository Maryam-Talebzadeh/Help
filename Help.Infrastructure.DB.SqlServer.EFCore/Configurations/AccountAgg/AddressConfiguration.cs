using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Description).HasMaxLength(1000);
            builder.Property(a => a.StreetName).HasMaxLength(100).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations

            builder.HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            builder.HasOne(a => a.Customer)
               .WithOne(c => c.Address)
               .HasForeignKey<Customer>(c => c.AddressId);

            #endregion
        }
    }
}

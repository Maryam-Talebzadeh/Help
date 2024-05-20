using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class CustomerPictureConfiguration : IEntityTypeConfiguration<CustomerPicture>
    {
        public void Configure(EntityTypeBuilder<CustomerPicture> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(100).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Seed Data

            var data = new CustomerPicture("DefaultProfile.jpg", "Default Customer Profile","Profile", 100);
            data.Id = 1;
            builder.HasData(data);

            #endregion
        }
    }
}

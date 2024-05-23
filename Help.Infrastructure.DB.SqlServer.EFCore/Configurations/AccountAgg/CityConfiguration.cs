using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.ProvinceName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ProvinceName).HasMaxLength(50);
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Seed Data

            var data = new City(" ", " ", " ");
            data.Id = 1;
            builder.HasData(data);

            #endregion
        }
    }
}

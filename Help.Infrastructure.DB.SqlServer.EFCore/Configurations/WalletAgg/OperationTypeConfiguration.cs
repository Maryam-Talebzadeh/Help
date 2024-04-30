using Help.Domain.Core.WalletAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.WalletAgg
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            #region Seed Data

            var data1 = new OperationType("واریز");
            data1.Id = 1;
            builder.HasData(data1);

            var data2 = new OperationType("برداشت");
            data2.Id = 2;
            builder.HasData(data2);

            #endregion
        }
    }
}

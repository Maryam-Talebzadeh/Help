using Help.Domain.Core.AccountAgg.Entities;
using Help.Domain.Core.WalletAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.WalletAgg
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations

            builder.HasMany(w => w.Operations)
              .WithOne(o => o.Wallet)
              .HasForeignKey(o => o.WalletId);

            builder.HasOne(w => w.Customer)
            .WithOne(c => c.Wallet)
            .HasForeignKey<Wallet>(w => w.CustomerId);

            #endregion
        }
    }
}

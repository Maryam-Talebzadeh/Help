using Help.Domain.Core.WalletAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.WalletAgg
{
    public class WalletOperationConfiguration : IEntityTypeConfiguration<WalletOperation>
    {
        public void Configure(EntityTypeBuilder<WalletOperation> builder)
        {
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations 

            builder.HasOne(wo => wo.Type)
           .WithMany(t => t.Operations)
           .HasForeignKey(wo => wo.TypeId);

            #endregion
        }
    }
}

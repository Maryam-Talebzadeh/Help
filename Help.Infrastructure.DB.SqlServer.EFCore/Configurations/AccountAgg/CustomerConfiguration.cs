using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FullName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.UserName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Relations

            builder.HasOne(c => c.Profile)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(p => p.PictureId);

            builder.HasMany(c => c.HelpRequests)
             .WithOne(h => h.Customer)
             .HasForeignKey(h => h.CustomerId);

            builder.HasMany(c => c.Skills)
           .WithOne(s => s.Customer)
           .HasForeignKey(s => s.CustomerId);

            builder.HasMany(c => c.Proposals)
           .WithOne(p => p.Customer)
           .HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Seed Data

            var data = new Customer("MaryamTalebzadeh", "Mary", "1234", "marya.6t@gmail.com", 5022201097588592, "09386485663", "first customer", 1, DateTime.Now, 1);
            data.Id = 100;
            builder.HasData(data);

            #endregion
        }
    }
}

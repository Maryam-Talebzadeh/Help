using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.AccountAgg
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired(false);

            builder.HasOne(c => c.Role)
               .WithMany(r => r.Admins).HasForeignKey(c => c.RoleId);

            #region Seed Data

            var data = new Admin(1,DateTime.Now.AddMonths(4),"MaryamTalebzadeh", "Mary", "10000.lyz67IGPgBUonnD4LNGVTQ==.4tH6b2mcWg+vVPSEHhzaEX0aatIlFdqGDcI+NUA/VLA=", "marya.6t@gmail.com", "09380000000", 1);
            data.Id = 1;
            builder.HasData(data);

            #endregion
        }
    }
}

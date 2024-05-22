using Help.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
    {
        public void Configure(EntityTypeBuilder<Assistant> builder)
        {
            builder.HasOne(c => c.Role)
               .WithMany(r => r.Assistants).HasForeignKey(c => c.RoleId);

            #region Seed Data

            var data = new Assistant(1, DateTime.Now.AddMonths(4), "Assistant", "Assistant1", "1234", "marya.6t@gmail.com", "09380000000", 3);
            data.Id = 1;
            builder.HasData(data);

            #endregion
        }
    }
}

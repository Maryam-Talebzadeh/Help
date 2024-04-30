using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class HelpRequestStatusConfiguration : IEntityTypeConfiguration<HelpRequestStatus>
    {
        public void Configure(EntityTypeBuilder<HelpRequestStatus> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Seed Data

            var data1 = new HelpRequestStatus("منتظر تایید ادمین", "درخواست شما اول باید توسط ادمین تایید شود. از صبوری شما سپاس گذاریم.");
            data1.Id = 1;
            builder.HasData(data1);

            var data2 = new HelpRequestStatus("انجام نشده", "منتظر پیشنهادات");
            data2.Id = 2;
            builder.HasData(data2);

            var data3 = new HelpRequestStatus("در حال انجام", "این درخواست در حال انجام می باشد.");
            data3.Id = 3;
            builder.HasData(data3);

            var data4 = new HelpRequestStatus("تمام شده", "این درخواست منقضی شده.");
            data4.Id = 4;
            builder.HasData(data4);

            #endregion
        }
    }
}

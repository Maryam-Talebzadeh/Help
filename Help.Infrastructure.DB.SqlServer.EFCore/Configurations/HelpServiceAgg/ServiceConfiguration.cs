using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg
{
    public class ServiceConfiguration : IEntityTypeConfiguration<HelpService>
    {
        public void Configure(EntityTypeBuilder<HelpService> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(10000);
            builder.Property(x => x.Tags).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);

            #region Seed Data

            var data = new HelpService("تعمیرات شیرآلات", "شیرآلات برای یک دلیل آشکار قسمت مهمی از خانه شما هستند: آن‌ها آب را برای انجام کارهای گوناگون توزیع می‌کنند. بنابراین، سالم نگه داشتن شیرآلات آشپزخانه، دستشویی و حمامدر شرایط درست کارکردشان امری ضروری است. برخی از موارد ممکن است باعث شود نیاز به تعمیر شیرآلات برند خاص پیدا کنید، از نشت آب گرفته تا سر و صدای اضافی. گاهی اوقات این مشکلات ناشی از قدیمی بودن شیرآلات است.", "تعمیرات شیرآلات", "تعمیرات-شیرآلات",1,1);
            data.Id = 1;
            builder.HasData(data);

            #endregion

            #region Relations

            builder.HasOne(s => s.Category)
              .WithMany(c => c.Services);

            builder.HasMany(s => s.Skills)
                .WithOne(s => s.HelpService)
                .HasForeignKey(s => s.ServiceId);

            builder.HasOne(s => s.Picture)
                .WithOne(p => p.HelpService)
                .HasForeignKey<HelpService>(p => p.PictureId);

            builder.HasMany(s => s.HelpRequests)
               .WithOne(s => s.HelpService)
               .HasForeignKey(s => s.ServiceId);

            #endregion

        }
    }
}

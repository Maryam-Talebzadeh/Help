using Help.Domain.Core.AccountAgg.Entities;
using Help.Domain.Core.ServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Configurations.ServiceAgg;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class HelpContext : DbContext
    {
        public HelpContext(DbContextOptions<HelpContext> options) :base(options)
        {
            
        }

        #region Service Agg

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServicePicture> ServicePictures { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<HelpRequest> HelpRequests { get; set; }
        public DbSet<HelpRequestStatus> HelpRequestStatuses { get; set; }
        public DbSet<HelpRequestPicture> HelpRequestPictures { get; set; }
        public DbSet<Comment> Comments { get; set; }

        #endregion

        #region Account Agg

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPicture> CustomerPictures { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(HelpRequestConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

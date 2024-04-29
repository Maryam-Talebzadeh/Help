using Help.Domain.Core.AccountAgg.Entities;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Domain.Core.WalletAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Configurations.HelpServiceAgg;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class HelpContext : DbContext
    {
        public HelpContext(DbContextOptions<HelpContext> options) :base(options)
        {
            
        }

        #region Service Agg

        public DbSet<HelpService> HelpServices { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Admin> Admins { get; set; }

        #endregion

        #region Wallet Agg

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletOperation> WalletOperations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(HelpRequestConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

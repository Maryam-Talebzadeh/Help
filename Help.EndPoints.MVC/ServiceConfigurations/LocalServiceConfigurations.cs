using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services.Cache;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.WalletAgg.Data;
using Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg;
using Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg;
using Help.Infrastructure.DataAccess.Repos.EFCore.WalletAgg;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Help.EndPoints.MVC.ServiceConfigurations
{
    public class LocalServiceConfigurations
    {
        public static void Configure(IServiceCollection services, string connectionString, ILogger logger)
        {

            #region HelpServiceAgg

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IHelpRequestPictureRepository, HelpRequestPictureRepository>();
            services.AddScoped<IHelpRequestRepository, HelpRequestRepository>();
            services.AddScoped<IHelpServicePictureRepository, HelpServicePictureRepository>();
            services.AddScoped<IHelpServiceRepository, HelpServiceRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            #endregion

            #region AccountAgg

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerPictureRepository, CustomerPictureRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion

            #region WalletAgg

            services.AddScoped<IWalletOperationRepository, WalletOperationRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            #endregion

            #region DBContext

            services.AddDbContext<HelpContext>(x => x.UseSqlServer(connectionString));

            #endregion

            #region Caching

            services.AddScoped<IDistributedCacheService, RedisCacheService>();

            #endregion

            #region Framework

            services.AddScoped<IOperationResultLogging>(provider => new OperationResultLogging(logger));

            #endregion
        }
    }
}

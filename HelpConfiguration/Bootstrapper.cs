﻿using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services.Cache;
using Base_Framework.General.Hashing;
using Base_Framework.LogError;
using Help.Domain.AppServices.AccountAgg;
using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.Services;
using Help.Domain.Core.WalletAgg.Data;
using Help.Domain.Services.AccountAgg;
using Help.Domain.Services.HelpServiceAgg;
using Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg;
using Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg;
using Help.Infrastructure.DataAccess.Repos.EFCore.WalletAgg;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelpConfiguration
{
    public static class Bootstrapper
    {
        public static void Configure(IServiceCollection services, ILogger<OperationResultLogging>? logger)
        {

            #region HelpServiceAgg

            #region Repositories

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IHelpRequestPictureRepository, HelpRequestPictureRepository>();
            services.AddScoped<IHelpRequestRepository, HelpRequestRepository>();
            services.AddScoped<IHelpRequestStatusRepository, HelpRequestStatusRepository>();
            services.AddScoped<IHelpServicePictureRepository, HelpServicePictureRepository>();
            services.AddScoped<IHelpServiceRepository, HelpServiceRepository>();
            services.AddScoped<IHelpServiceCategoryRepository, HelpServiceCategoryRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            #endregion

            #region Services

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IHelpServiceService, HelpServiceService>();
            services.AddScoped<IHelpServiceCategoryService, HelpServiceCategoryService>();
            services.AddScoped<IHelpServicePictureService, HelpServicePictureService>();
            services.AddScoped<IHelpRequestService, HelpRequestService>();
            services.AddScoped<IHelpRequestPictureService, HelpRequestPictureService>();
            services.AddScoped<IHelpRequestStatusService, HelpRequestStatusService>();

            #endregion

            #region AppServices

            services.AddScoped<ICommentAppService, CommentAppService>();
            services.AddScoped<IHelpServiceAppService, HelpServiceAppService>();
            services.AddScoped<IHelpServiceCategoryAppService, HelpServiceCategoryAppService>();
            services.AddScoped<IHelpServicePictureAppService, HelpServicePictureAppService>();
            services.AddScoped<IHelpRequestAppService, HelpRequestAppService>();
            services.AddScoped<IHelpRequestPictureAppService, HelpRequestPictureAppService>();
            services.AddScoped<IHelpRequestStatusAppService, HelpRequestStatusAppService>();

            #endregion

            #endregion

            #region AccountAgg

            #region Repositories

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerPictureRepository, CustomerPictureRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion

            #region Services

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerPictureService, CustomerPictureService>();

            #endregion

            #region AppServices

            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomerPictureAppService, CustomerPictureAppService>();

            #endregion

            #endregion

            #region WalletAgg

            services.AddScoped<IWalletOperationRepository, WalletOperationRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            #endregion

            #region Caching

            services.AddScoped<IDistributedCacheService, RedisCacheService>();

            #endregion

            #region Framework

            services.AddScoped<IOperationResultLogging>(provider => new OperationResultLogging(logger));
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            #endregion
        }
    }
}

﻿using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpServiceAppService : IHelpServiceAppService
    {
        private readonly IHelpServiceService _helpServiceService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpServiceDTO().GetType();
        private readonly IDistributedCacheService _distributedCache;
        private readonly SiteSetting _appSetting;

        public HelpServiceAppService(IHelpServiceService helpServiceService, IOperationResultLogging operationResultLogging, IDistributedCacheService distributedCache, SiteSetting appSetting)
        {
            _helpServiceService = helpServiceService;
            _operationResultLogging = operationResultLogging;
            _distributedCache = distributedCache;
            _appSetting = appSetting;
        }

        public async Task<OperationResult> Create(CreateHelpServiceDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServiceService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpServiceService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServiceService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpServiceService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }


        public async Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return await _helpServiceService.GetAllRemoved(cancellationToken);
        }

        public async Task<EditHelpServiceDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var res = await _distributedCache.GetAsync<EditHelpServiceDTO>(_appSetting.HelpServicesCacheKey+"_"+id);

            if(res == null)
            {
                var detail = await _helpServiceService.GetDetails(id, cancellationToken);
                await _distributedCache.SetAsync(_appSetting.HelpServicesCacheKey, detail, 7, TimeSpan.FromHours(2));
                res = detail;
            }

            if (res == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return res;
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServiceService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpServiceService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpServiceDTO>> Search(SearchHelpServiceDTO searchModel, CancellationToken cancellationToken)
        {
            //Fill IdTitleCategoryDTO

            var res = await _distributedCache.GetListAsync<HelpServiceDTO>(_appSetting.HelpServicesCacheKey);
            if (res == null)
            {
                var helpServices = await _helpServiceService.GetAll(cancellationToken);
                await _distributedCache.SetAsync(_appSetting.HelpServicesCacheKey, helpServices, 7, TimeSpan.FromHours(2));
                res = helpServices;
            }
            return await _helpServiceService.Search(res, searchModel, cancellationToken);
        }
    }
}
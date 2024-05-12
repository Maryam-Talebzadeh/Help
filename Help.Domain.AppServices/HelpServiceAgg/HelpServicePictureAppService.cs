using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpServicePictureAppService : IHelpServicePictureAppService
    {
        private readonly IHelpServicePictureService _helpServicePictureService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpServicePictureDTO().GetType();
        private readonly IDistributedCacheService _distributedCache;
        private readonly SiteSetting _appSetting;

        public HelpServicePictureAppService(IHelpServicePictureService helpServicePictureService, IOperationResultLogging operationResultLogging, IDistributedCacheService distributedCache, SiteSetting appSetting)
        {
            _helpServicePictureService = helpServicePictureService;
            _operationResultLogging = operationResultLogging;
            _distributedCache = distributedCache;
            _appSetting = appSetting;
        }

        public async Task<OperationResult> Create(CreateHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServicePictureService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpServicePictureService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServicePictureService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpServicePictureService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var res = await _distributedCache.GetAsync<EditHelpServicePictureDTO>(_appSetting.HelpServicesCacheKey + "_" + id);

            if (res == null)
            {
                var detail = await _helpServicePictureService.GetDetails(id, cancellationToken);
                await _distributedCache.SetAsync((_appSetting.HelpServicePicturessCacheKey + "_" + id), detail, 7, TimeSpan.FromHours(2));
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
                return await _helpServicePictureService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpServicePictureService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }
    }
}

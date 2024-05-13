using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpServiceCategoryAppService : IHelpServiceCategoryAppService
    {
        private readonly IHelpServiceCategoryService _helpServiceCategoryService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpServiceCategoryDTO().GetType();
        private readonly IDistributedCacheService _distributedCache;
        private readonly SiteSetting _appSetting;

        public HelpServiceCategoryAppService(IHelpServiceCategoryService helpServiceCategoryService, IOperationResultLogging operationResultLogging, IDistributedCacheService distributedCache, SiteSetting appSetting)
        {
            _helpServiceCategoryService = helpServiceCategoryService;
            _operationResultLogging = operationResultLogging;
            _distributedCache = distributedCache;
            _appSetting = appSetting;
        }

        public async Task<OperationResult> CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await  _helpServiceCategoryService.CreateChild(command, cancellationToken);
            }
            catch
            {
                var operation = await  _helpServiceCategoryService.CreateChild(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(CreateChild), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpServiceCategoryService.CreateParent(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpServiceCategoryService.CreateParent(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(CreateParent), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await  _helpServiceCategoryService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await  _helpServiceCategoryService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllParents(CancellationToken cancellationToken)
        {
            return await  _helpServiceCategoryService.GetAllParents(cancellationToken);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return await  _helpServiceCategoryService.GetAllRemoved(cancellationToken);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return await  _helpServiceCategoryService.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var res = await _distributedCache.GetAsync<HelpServiceCategoryDetailDTO>(_appSetting.HelpServiceCategoriesCacheKey + "_" + id);

            if (res == null)
            {
                var detail = await  _helpServiceCategoryService.GetDetails(id, cancellationToken);
                await _distributedCache.SetAsync((_appSetting.HelpServiceCategoriesCacheKey + "_" + id), detail, 7, TimeSpan.FromHours(2));
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
                return await  _helpServiceCategoryService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await  _helpServiceCategoryService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpServiceCategoryDTO>> Search(List<HelpServiceCategoryDTO> searchList, SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            var res = await _distributedCache.GetListAsync<HelpServiceCategoryDTO>(_appSetting.HelpServiceCategoriesCacheKey);
            if (res == null)
            {
                var categories = await  _helpServiceCategoryService.GetAll(cancellationToken);
                await _distributedCache.SetAsync(_appSetting.HelpServiceCategoriesCacheKey, categories, 7, TimeSpan.FromHours(2));
                res = categories;
            }
            return await  _helpServiceCategoryService.Search(res, searchModel, cancellationToken);
        }
    }
}

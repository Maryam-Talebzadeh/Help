using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Services.AccountAgg;

namespace Help.Domain.AppServices.AccountAgg
{
    public class CityAppService : ICityAppService
    {
        private readonly ICityService _cityService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(CityAppService).Namespace;


        public CityAppService(ICityService cityService, IOperationResultLogging operationResultLogging)
        {
            _cityService = cityService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Create(CreateCityDTO command, CancellationToken cancellationToken)
        {
            var operation = await  _cityService .Create(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<OperationResult> Edit(EditCityDTO command, CancellationToken cancellationToken)
        {
            var operation = await  _cityService .Edit(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<List<CityDTO>> Search(SearchCityDTO searchModel, CancellationToken cancellationToken)
        {
            return await _cityService.Search(searchModel, cancellationToken);
        }
    }
}

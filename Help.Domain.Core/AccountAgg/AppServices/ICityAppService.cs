using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.City;

namespace Help.Domain.Core.AccountAgg.AppServices
{
    public interface ICityAppService
    {
        Task<OperationResult> Create(CreateCityDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCityDTO command, CancellationToken cancellationToken);
        Task<List<CityDTO>> Search(SearchCityDTO searchModel, CancellationToken cancellationToken);
    }
}

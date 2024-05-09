using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICityRepository : IRepository<City>
    {
        Task<int> Create(CreateCityDTO command, CancellationToken cancellationToken);
        Task Edit(EditCityDTO command, CancellationToken cancellationToken);
        Task<List<CityDTO>> Search(SearchCityDTO searchModel, CancellationToken cancellationToken);
    }
}

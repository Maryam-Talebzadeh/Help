using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICityRepository : IRepository<City>
    {
        void Create(CreateCityDTO command);
        void Edit(EditCityDTO command);
        List<CityDTO> Search(SearchCityDTO searchModel);
    }
}

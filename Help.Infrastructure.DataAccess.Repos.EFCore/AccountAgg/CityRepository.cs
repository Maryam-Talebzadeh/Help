using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class CityRepository : BaseRepository_EFCore<City>, ICityRepository
    {
        private readonly HelpContext _context;

        public CityRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateCityDTO command)
        {
            var city = new City(command.Name, command.ProvinceName, command.Code);
            _context.Cities.Add(city);
        }

        public void Edit(EditCityDTO command)
        {
            var city = Get(command.Id);
            city.Edit(command.Name, command.ProvinceName, command.Code);
        }

       public List<CityDTO> Search(SearchCityDTO searchModel)
        {
            var query = _context.Cities.Select(c =>
            new CityDTO()
            {
                Code = c.Code,
                Name = c.Name,
                ProvinceName = c.ProvinceName
            });

            if(!searchModel.Name.IsNullOrEmpty())
                query = query.Where(c => c.Name.Contains(searchModel.Name));

            if (!searchModel.Code.IsNullOrEmpty())
                query = query.Where(c => c.Code == searchModel.Code);

            return query.OrderBy(c => c.Name).ToList();
        }
    }
}

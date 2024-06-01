using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface ICityService
    {
        Task<OperationResult> Create(CreateCityDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCityDTO command, CancellationToken cancellationToken);
        Task<List<CityDTO>> Search(SearchCityDTO searchModel, CancellationToken cancellationToken);
    }
}

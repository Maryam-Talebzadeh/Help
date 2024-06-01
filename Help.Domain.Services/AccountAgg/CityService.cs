using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        private readonly Type _type = new CityDTO().GetType();

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<OperationResult> Create(CreateCityDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            if ( await _cityRepository.IsExist(c => c.Name == command.Name && c.ProvinceName == command.ProvinceName && c.Code == command.Code, cancellationToken))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            
                await _cityRepository.Create(command, cancellationToken);
                await _cityRepository.Save(cancellationToken);
                return operation.Succedded();
                                 
        }

        public async Task<OperationResult> Edit(EditCityDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _cityRepository.IsExist(r => r.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (await _cityRepository.IsExist(c => c.Name == command.Name && c.ProvinceName == command.ProvinceName && c.Code == command.Code && c.Id != command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            await _cityRepository.Edit(command, cancellationToken);
            await _cityRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<CityDTO>> Search(SearchCityDTO searchModel, CancellationToken cancellationToken)
        {
            return await _cityRepository.Search(searchModel, cancellationToken);
        }
    }
}

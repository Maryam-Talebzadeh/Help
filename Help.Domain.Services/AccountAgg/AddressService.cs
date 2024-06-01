using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        private readonly Type _type = new AddressDTO().GetType();

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<OperationResult> Edit(EditAddressDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (!await _addressRepository.IsExist(r => r.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _addressRepository.Edit(command, cancellationToken);
            await _addressRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditAddressDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetDetails(id, cancellationToken);
            return address;
        }
    }
}

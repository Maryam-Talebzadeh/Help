using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.AppServices.AccountAgg
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressService _addressService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(AddressAppService).Namespace;
        private readonly Type _type = new AddressDTO().GetType();


        public AddressAppService(IAddressService addressService, IOperationResultLogging operationResultLogging)
        {
            _addressService = addressService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Edit(EditAddressDTO command, CancellationToken cancellationToken)
        {
            var operation = await _addressService.Edit(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<EditAddressDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _addressService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }
    }
}

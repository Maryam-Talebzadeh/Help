using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.AppServices.AccountAgg
{
    public class CustomerPictureAppService : ICustomerPictureAppService
    {
        private readonly ICustomerPictureService _customerPictureService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(CustomerPictureAppService).Namespace;
        private readonly Type _type = new CustomerPictureDTO().GetType();

        public CustomerPictureAppService(ICustomerPictureService customerPictureService, IOperationResultLogging operationResultLogging)
        {
            _customerPictureService = customerPictureService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {

            var operation = await _customerPictureService.Confirm(id, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Confirm), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;

        }


        public async Task<OperationResult> Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var operation = await _customerPictureService.Edit(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<CustomerPictureDTO> GetByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            var picture = await _customerPictureService.GetByCustomerId(customerId, cancellationToken);

            if (picture == null)
            {
                var operation = new OperationResult(_type, customerId);
                _operationResultLogging.LogOperationResult(operation.Failed(ApplicationMessages.RecordNotFound), nameof(GetByCustomerId), _nameSpace, cancellationToken);
            }

            return picture;
        }

        public async Task<EditCustomerPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var picture = await _customerPictureService.GetDetails(id, cancellationToken);

            if (picture == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation.Failed(ApplicationMessages.RecordNotFound), nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return picture;
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            var operation = await _customerPictureService.Reject(id, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Reject), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = await _customerPictureService.Remove(id, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<List<CustomerPictureDTO>> SearchUnChecked(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerPictureService.SearchUnChecked(searchModel, cancellationToken);
        }

        public async Task<List<CustomerPictureDTO>> Search(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerPictureService.Search(searchModel, cancellationToken);
        }

        public async Task<OperationResult> EditDefaultProfile(EditCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var operation = await _customerPictureService.EditDefaultProfile(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(EditDefaultProfile), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }
    }
}

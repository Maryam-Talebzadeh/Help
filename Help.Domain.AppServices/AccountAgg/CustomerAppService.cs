using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.AppServices.AccountAgg
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerPictureService _customerPictureService;

        private readonly IVoteAppService _voteAppService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(CustomerAppService).Namespace;
        private readonly Type _type = new CustomerDTO().GetType();

        public CustomerAppService(ICustomerService customerService, ICustomerPictureService customerPictureService, IOperationResultLogging operationResultLogging, IVoteAppService voteAppService)
        {
            _customerService = customerService;
            _customerPictureService = customerPictureService;
            _operationResultLogging = operationResultLogging;
            _voteAppService = voteAppService;
        }

        public async Task<OperationResult> Active(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.Active(id, cancellationToken);
            }
            catch
            {
                var operation = await _customerService.Active(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Active), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> ChangePassword(ChangeCustomerPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.ChangePassword(changePasswordModel, cancellationToken);
            }
            catch
            {
                var operation = await _customerService.ChangePassword(changePasswordModel, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(ChangePassword), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Register(CreateCustomerDTO command, CancellationToken cancellationToken)
        {
            var operation = await _customerService.Register(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Register), _nameSpace, cancellationToken);
                return operation;
            }

            var picture = new CreateCustomerPictureDTO()
            {
                CustomerID = operation.RecordReferenceId,               
            };

            operation = await _customerPictureService.CreateDefault(picture, cancellationToken);

            return operation;
        }

        public async Task<OperationResult> DeActive(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.DeActive(id, cancellationToken);
            }
            catch
            {
                var operation = await _customerService.DeActive(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(DeActive), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditCustomerDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _customerService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _customerService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            detail.RateAsExpert = await _voteAppService.GetRateAsExpert(id, cancellationToken);
            detail.RateAsRequester = await _voteAppService.GetRateAsRequester(id, cancellationToken);
            return detail;
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _customerService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerService.Search(searchModel, cancellationToken);
        }
    }
}

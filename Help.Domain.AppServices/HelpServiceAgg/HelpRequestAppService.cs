using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpRequestAppService : IHelpRequestAppService
    {
        private readonly IHelpRequestService _helpRequestService;
        private readonly IHelpRequestPictureService _helpRequestPictureService;
        private readonly IDistributedCacheService _cacheService;
        private readonly OperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpRequestDTO().GetType();

        public HelpRequestAppService(IHelpRequestService helpRequestService, IDistributedCacheService cacheService, OperationResultLogging operationResultLogging, IHelpRequestPictureService helpRequestPictureService)
        {
            _helpRequestService = helpRequestService;
            _cacheService = cacheService;
            _operationResultLogging = operationResultLogging;
            _helpRequestPictureService = helpRequestPictureService;
            _helpRequestPictureService = helpRequestPictureService;
        }

        public async Task<OperationResult> ChangeStatus(int helpRequestId, int customerId, int statusId, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.ChangeStatus(helpRequestId, customerId, statusId, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.ChangeStatus(helpRequestId, customerId, statusId, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(ChangeStatus), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Confirm(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Confirm(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Confirm), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<int> Count(CancellationToken cancellationToken)
        {
            return await _helpRequestService.Count(cancellationToken);
        }

        public async Task<OperationResult> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Done(int helpRequestId, int customerId, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Done(helpRequestId, customerId, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Done(helpRequestId, customerId, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Done), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpRequestDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpRequestDTO>> GetAllUnConfirmed(CancellationToken cancellation)
        {
            return await _helpRequestService.GetAllUnConfirmed(cancellation);
        }

        public async Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _helpRequestService.GetDetails(id, cancellationToken);

           if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Reject(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Reject(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Reject), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
            var requests = await _helpRequestService.Search(searchModel, cancellationToken);

            foreach (var request in requests)
            {
                request.Pictures = await _helpRequestPictureService.GetAll(request.Id, cancellationToken);
                //customerDTO
                //HelpServiceDTOO
            }

            return requests;
        }
    }
}

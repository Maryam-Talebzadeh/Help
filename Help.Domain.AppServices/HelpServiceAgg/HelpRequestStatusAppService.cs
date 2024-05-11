using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestStatus;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpRequestStatusAppService : IHelpRequestStatusAppService
    {
        private readonly IHelpRequestStatusService _helpRequestStatusService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpRequestStatusDTO().GetType();

        public HelpRequestStatusAppService(IHelpRequestStatusService helpRequestStatusService, IOperationResultLogging operationResultLogging)
        {
            _helpRequestStatusService = helpRequestStatusService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Create(CreateHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestStatusService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestStatusService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestStatusService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestStatusService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpRequestStatusDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _helpRequestStatusService.GetAll(cancellationToken);
        }

        public async Task<EditHelpRequestStatusDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _helpRequestStatusService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestStatusService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestStatusService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }
    }
}

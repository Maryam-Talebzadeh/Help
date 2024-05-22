using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Assistant;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Services.AccountAgg;
using Microsoft.Win32;

namespace Help.Domain.AppServices.AccountAgg
{
    public class AssistantAppService : IAssistantAppService
    {
        private readonly IAssistantService _assistantService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(AssistantAppService).Namespace;
        private readonly Type _type = new AssistantDTO().GetType();

        public AssistantAppService(IAssistantService assistantService, IOperationResultLogging operationResultLogging)
        {
            _assistantService = assistantService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> ChangePassword(ChangeAssistantPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            
               var operation = await _assistantService.ChangePassword(changePasswordModel, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(ChangePassword), _nameSpace, cancellationToken);
                return operation;
            }

                return operation;
            
        }

        public async Task<OperationResult> Create(CreateAssistantDTO command, CancellationToken cancellationToken)
        {
            var operation = await _assistantService.Create(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<OperationResult> Edit(EditAssistantDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _assistantService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _assistantService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<EditAssistantDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _assistantService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<List<AssistantDTO>> Search(SearchAssistantDTO searchModel, CancellationToken cancellationToken)
        {
            return await _assistantService.Search(searchModel, cancellationToken);
        }
    }
}

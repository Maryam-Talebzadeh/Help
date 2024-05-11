using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpRequestPictureAppService : IHelpRequestPictureAppService
    {
        private readonly IHelpRequestPictureService _helpRequestPictureService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = "Help.Domain.AppServices.HelpServiceAgg";
        private readonly Type _type = new HelpRequestPictureDTO().GetType();

        public HelpRequestPictureAppService(IHelpRequestPictureService helpRequestPictureService, IOperationResultLogging operationResultLogging)
        {
            _helpRequestPictureService = helpRequestPictureService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestPictureService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestPictureService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestPictureService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestPictureService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken)
        {
            return await _helpRequestPictureService.GetAll(helpRequestId, cancellationToken);
        }

        public async Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(int helpRequestId, CancellationToken cancellationToken)
        {
            return await _helpRequestPictureService.GetAllUnConfirmed(helpRequestId, cancellationToken);
        }

        public async Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _helpRequestPictureService.GetDetails(id, cancellationToken);

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
                return await _helpRequestPictureService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestPictureService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }
    }
}

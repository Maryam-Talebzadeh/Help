using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpServicePictureAppService : IHelpServicePictureAppService
    {
        private readonly IHelpServicePictureService _HelpServicePictureService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(HelpServicePictureAppService).Namespace;
        private readonly Type _type = new HelpServicePictureDTO().GetType();

        public HelpServicePictureAppService(IHelpServicePictureService HelpServicePictureService, IOperationResultLogging operationResultLogging)
        {
            _HelpServicePictureService = HelpServicePictureService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> EditDefaultPicture(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var operation = await _HelpServicePictureService.EditDefaultPicture(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(EditDefaultPicture), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public Task<OperationResult> EditDefaultProfile(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<HelpServicePictureDTO> GetByHelpServiceId(int HelpServiceId, CancellationToken cancellationToken)
        {
            var picture = await _HelpServicePictureService.GetByHelpServiceId(HelpServiceId, cancellationToken);

            if (picture == null)
            {
                var operation = new OperationResult(_type, HelpServiceId);
                _operationResultLogging.LogOperationResult(operation.Failed(ApplicationMessages.RecordNotFound), nameof(GetByHelpServiceId), _nameSpace, cancellationToken);
            }

            return picture;
        }

        public async Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var picture = await _HelpServicePictureService.GetDetails(id, cancellationToken);

            if (picture == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation.Failed(ApplicationMessages.RecordNotFound), nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return picture;
        }
    }
}

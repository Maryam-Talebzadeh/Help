using Base_Framework.Domain.Core.Entities;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class HelpRequestAppService : IHelpRequestAppService
    {
        private readonly IHelpRequestService _helpRequestService;
        private readonly IHelpRequestPictureService _helpRequestPictureService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(HelpRequestAppService).Namespace;
        private readonly Type _type = new HelpRequestDTO().GetType();

        public HelpRequestAppService(IHelpRequestService helpRequestService, IOperationResultLogging operationResultLogging, IHelpRequestPictureService helpRequestPictureService)
        {
            _helpRequestService = helpRequestService;
            _operationResultLogging = operationResultLogging;
            _helpRequestPictureService = helpRequestPictureService;
        }

        public async Task<OperationResult> ChangeStatus(int helpRequestId, int statusId, CancellationToken cancellationToken)
        {
            try
            {
                return await _helpRequestService.ChangeStatus(helpRequestId, statusId, cancellationToken);
            }
            catch
            {
                var operation = await _helpRequestService.ChangeStatus(helpRequestId, statusId, cancellationToken);
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
            var operation = await _helpRequestService.Create(command, cancellationToken);

            if(!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation.Failed(ApplicationMessages.CreationFailed);
            }

            var picture = new CreateHelpRequestPictureDTO
            {              
                HelpRequestId = operation.RecordReferenceId,
                Alt = "عکس درخواست" + command.Title,
                Title = "عکس درخواست" + command.Title
            };

            if (command.Picture1 != null)
            {
                picture.Picture = command.Picture1;
                operation = await _helpRequestPictureService.Create(picture, cancellationToken);
            }
            if(command.Picture2 != null)
            {
                picture.Picture = command.Picture2;
                operation = await _helpRequestPictureService.Create(picture, cancellationToken);

            }
           if(command.Picture2 == null && command.Picture1 == null)
            {
                operation = await _helpRequestPictureService.CreateDefault(picture, cancellationToken);
            }

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation.Failed(ApplicationMessages.CreationFailed);
            }

            return operation;
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
            var operation = await _helpRequestService.Edit(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation.Failed(ApplicationMessages.CreationFailed);
            }

            var picture = new EditHelpRequestPictureDTO
            {
                HelpRequestId = operation.RecordReferenceId,
                Alt = "عکس درخواست" + command.Title,
                Title = "عکس درخواست" + command.Title
            };

            if (command.Picture1 != null)
            {
                picture.Picture = command.Picture1;
                picture.Id = command.Picture1Detail.Id;
                picture.Name = command.Picture1Detail.Name;
                operation = await _helpRequestPictureService.Edit(picture, cancellationToken);
            }
           if (command.Picture2 != null)
            {
                picture.Picture = command.Picture2;
                picture.Id = command.Picture2Detail.Id;
                picture.Name = command.Picture1Detail.Name;
                operation = await _helpRequestPictureService.Edit(picture, cancellationToken);

            }


            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation.Failed(ApplicationMessages.CreationFailed);
            }

            return operation;
        }

        public async Task<List<HelpRequestDTO>> SearchInUnChecked(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            return await _helpRequestService.SearchInUnChecked(searchModel, cancellation);
        }

        public async Task<HelpRequestDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _helpRequestService.GetDetails(id, cancellationToken);

           if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            var pictures = await _helpRequestPictureService.GetAll(id, cancellationToken);

            detail.Picture1Detail = pictures.First();
            detail.Picture2Detail = pictures.Count() > 1 ? pictures.Last() : null;

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
            }

            return requests;
        }

        public async Task<List<HelpRequestDTO>> SearchInRejected(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            return await _helpRequestService.SearchInRejected(searchModel, cancellation);
        }

        public async Task<List<HelpRequestDTO>> GetAllConfirmed(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            var requests = await _helpRequestService.GetAllConfirmed(searchModel, cancellation);

            foreach (var request in requests)
            {
                request.Pictures = await _helpRequestPictureService.GetAll(request.Id, cancellation);
            }

            return requests;
        }
    }
}

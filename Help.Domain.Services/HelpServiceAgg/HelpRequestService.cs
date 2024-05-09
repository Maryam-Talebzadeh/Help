using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpRequestService : IHelpRequestService
    {
        private readonly IHelpRequestRepository _helpRequestRepository;
        private readonly IHelpRequestPictureRepository _helpRequestPictureRepository;

        public HelpRequestService(IHelpRequestRepository helpRequestRepository, IHelpRequestPictureRepository helpRequestPictureRepository)
        {
            _helpRequestRepository = helpRequestRepository;
            _helpRequestPictureRepository = helpRequestPictureRepository;
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> ChangeStatus(int helpRequestId, int customerId, int statusId, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = helpRequestId
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == helpRequestId, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (!await _helpRequestRepository.IsExist(x => x.CustomerId == customerId, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.ChangeStatus(helpRequestId, statusId, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Confirm(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = id
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Confirm(id, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<int> Count(CancellationToken cancellationToken)
        {
           return await _helpRequestRepository.Count(cancellationToken);
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO());
            await _helpRequestRepository.Create(command, cancellationToken);

            return operation.Succedded();         
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Done(int helpRequestId, int customerId, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = helpRequestId
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == helpRequestId, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Done(helpRequestId, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Edit(EditHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = command.Id
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Edit(command, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestDTO>> GetAllUnConfirmed(CancellationToken cancellation)
        {
            return await _helpRequestRepository.GetAllUnConfirmed(cancellation);
        }

        public Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _helpRequestRepository.GetDetails(id, cancellationToken);
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Reject(int id, int adminCode, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = id
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Reject(id, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult<HelpRequestDTO>> Remove(int id, int adminCode, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<HelpRequestDTO>(new HelpRequestDTO()
            {
                Id = id
            });

            if (!await _helpRequestRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Remove(id, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
            var helpRequests = await _helpRequestRepository.Search(searchModel, cancellationToken);

            foreach (var request in helpRequests)
                request.Pictures = await _helpRequestPictureRepository.GetAll(cancellationToken);

            return helpRequests;
        }
    }
}

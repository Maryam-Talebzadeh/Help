using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Services;
using System.Threading;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpRequestService : IHelpRequestService
    {
        private readonly IHelpRequestRepository _helpRequestRepository;
        private readonly Type _type = new HelpRequestDTO().GetType();

        public HelpRequestService(IHelpRequestRepository helpRequestRepository)
        {
            _helpRequestRepository = helpRequestRepository;
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> ChangeStatus(int helpRequestId, int statusId, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, helpRequestId);

            if (!await _helpRequestRepository.IsExist(x => x.Id == helpRequestId, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.ChangeStatus(helpRequestId, statusId, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

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

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);
           int id = await _helpRequestRepository.Create(command, cancellationToken);
            operation.RecordReferenceId = id
    ;
            return operation.Succedded();         
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Done(int helpRequestId, int customerId, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, helpRequestId);

            if (!await _helpRequestRepository.IsExist(x => x.Id == helpRequestId, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Done(helpRequestId, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Edit(EditHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (!await _helpRequestRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Edit(command, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestDTO>> SearchInUnChecked(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            return await _helpRequestRepository.SearchInUnChecked(searchModel, cancellation);
        }

        public async Task<HelpRequestDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpRequestRepository.GetDetails(id, cancellationToken);
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _helpRequestRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Reject(id, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _helpRequestRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestRepository.Remove(id, cancellationToken);
            await _helpRequestRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
            return await _helpRequestRepository.Search(searchModel, cancellationToken);
        }

        public async Task<List<HelpRequestDTO>> SearchInRejected(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            return await _helpRequestRepository.SearchInRejected(searchModel, cancellation);
        }

        public async Task<List<HelpRequestDTO>> GetAllConfirmed(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            return await _helpRequestRepository.GetAllConfirmed(searchModel, cancellation);
        }
    }
}

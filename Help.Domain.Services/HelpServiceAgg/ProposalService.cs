using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Services;


namespace Help.Domain.Services.HelpServiceAgg
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly Type _type = new ProposalDTO().GetType();

        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _proposalRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _proposalRepository.Confirm(id, cancellationToken);
            await _proposalRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Create(CreateProposalDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);
            await _proposalRepository.Create(command, cancellationToken);
            await _proposalRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditProposalDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (!await _proposalRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _proposalRepository.Edit(command, cancellationToken);
            await _proposalRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _proposalRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _proposalRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _proposalRepository.Reject(id, cancellationToken);
            await _proposalRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            return await _proposalRepository.Search(searchModel, cancellationToken);
        }

        public async Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            return await _proposalRepository.SearchUnConfirmed(searchModel, cancellationToken);
        }
    }
}

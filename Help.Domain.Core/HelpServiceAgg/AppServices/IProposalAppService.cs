using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IProposalAppService
    {
        Task<OperationResult> Create(CreateProposalDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditProposalDTO command, CancellationToken cancellationToken);
        Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(int id, int helpRequestId, CancellationToken cancellationToken);
        Task<OperationResult> Reject(int id, CancellationToken cancellationToken);
    }
}

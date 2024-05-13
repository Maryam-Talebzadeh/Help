using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Task Create(CreateProposalDTO command, CancellationToken cancellationToken);
        Task Edit(EditProposalDTO command, CancellationToken cancellationToken);
        Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task Confirm(int id, CancellationToken cancellationToken);
    }
}

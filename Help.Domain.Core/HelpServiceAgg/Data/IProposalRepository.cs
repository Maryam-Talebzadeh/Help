using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        void Create(CreateProposalDTO command);
        void Edit(EditProposalDTO command);
        EditProposalDTO GetDetails(long id);
        List<ProposalDTO> Search(SearchProposaltDTO searchModel);
        List<ProposalDTO> GetAllUnConfirmed(SearchProposaltDTO searchModel);
        void Confirm(long id);
    }
}

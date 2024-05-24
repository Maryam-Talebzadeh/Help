using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IProposalService
    {
        Task<OperationResult> Create(CreateProposalDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditProposalDTO command, CancellationToken cancellationToken);
        Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(int id, CancellationToken cancellationToken);
    }
}

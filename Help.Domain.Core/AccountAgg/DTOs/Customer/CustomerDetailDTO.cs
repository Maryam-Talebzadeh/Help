using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.DTOs.Skill;

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CustomerDetailDTO : EditCustomerDTO
    {
        public string Profile { get; set; } // Temporary
        public List<SkillDTO> Skills { get; set; }
        public List<HelpRequestDTO> HelpRequests { get; set; }
        public List<ProposalDTO> Proposals { get; set; }
        public long WalletId { get; set; } // Temporary
    }
}

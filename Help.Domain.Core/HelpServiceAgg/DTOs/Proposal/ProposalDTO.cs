

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Proposal
{
    public class ProposalDTO
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public double SuggestedPrice { get; set; }
        public HelpRequestDTO HelpRequest { get; set; }
        public long CustomerId { get; set; } //Temporary
    }
}

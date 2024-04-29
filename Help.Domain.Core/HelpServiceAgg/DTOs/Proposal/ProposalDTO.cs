

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Proposal
{
    public class ProposalDTO
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; private set; }
        public double SuggestedPrice { get; private set; }
        public HelpRequestDTO HelpRequest { get; private set; }
        public long CustomerId { get; private set; } //Temporary
    }
}

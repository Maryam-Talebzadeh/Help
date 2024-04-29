

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Proposal
{
    public class CreateProposalDTO
    {
        public string Description { get; set; }
        public DateTime SuggestedTime { get; set; }
        public double SuggestedPrice { get; set; }
        public long HelpRequestId { get; set; }
        public long CustomerId { get; set; }
    }
}

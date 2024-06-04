

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Proposal
{
    public class CreateProposalDTO
    {
        public string Description { get; set; }
        public string SuggestedTime { get; set; }
        public double SuggestedPrice { get; set; }
        public int HelpRequestId { get; set; }
        public int CustomerId { get; set; }
        public int HelpRequestCustomerId { get; set; }
       
    }
}

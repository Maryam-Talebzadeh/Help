

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class CreateHelpRequestDTO
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ExpirationDate { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public double ProposedPrice { get; private set; }
    }
}

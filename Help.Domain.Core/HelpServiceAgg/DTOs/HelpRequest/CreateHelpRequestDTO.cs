

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class CreateHelpRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public double ProposedPrice { get; set; }
    }
}

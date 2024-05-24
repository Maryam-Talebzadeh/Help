

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class SearchHelpRequestDTO
    {
        public string Title { get; set; }
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
    }
}

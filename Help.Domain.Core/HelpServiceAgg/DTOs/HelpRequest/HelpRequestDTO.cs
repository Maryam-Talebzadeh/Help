

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class HelpRequestDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsDone { get; set; }
        public long CustomerId { get; set; } //Temporary > IdTitleDTo
        public IdTitleHelpServiceDTO HelpService { get; set; }
    }
}

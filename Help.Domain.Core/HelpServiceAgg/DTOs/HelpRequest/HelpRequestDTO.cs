
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class HelpRequestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsDone { get; set; }
        public CustomerDTO Customer { get; set; } 
        public IdTitleHelpServiceDTO HelpService { get; set; }
    }
}

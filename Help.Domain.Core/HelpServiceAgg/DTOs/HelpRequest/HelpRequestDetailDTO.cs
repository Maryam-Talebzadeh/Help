

using Help.Domain.Core.AccountAgg.DTOs.Customer;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class HelpRequestDetailDTO : EditHelpRequestDTO
    {
        public CustomerDTO Customer { get; set; }
    }
}



using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class EditHelpRequestDTO : CreateHelpRequestDTO
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public HelpRequestPictureDTO? Picture1Detail { get; set; }
        public HelpRequestPictureDTO? Picture2Detail { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}

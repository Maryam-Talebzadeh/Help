

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture
{
    public class CreateHelpRequestPictureDTO
    {
        public long HelpRequestId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
    }
}

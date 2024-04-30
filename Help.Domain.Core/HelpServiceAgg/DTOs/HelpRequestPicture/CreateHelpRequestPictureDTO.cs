

using Base_Framework.Domain.Core.DTOs;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture
{
    public class CreateHelpRequestPictureDTO : PictureDTO
    {
        public int HelpRequestId { get; set; }
    }
}

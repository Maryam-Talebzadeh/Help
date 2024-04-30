using Base_Framework.Domain.Core.DTOs;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture
{
    public class CreateHelpServicePictureDTO : PictureDTO
    {
        public int HelpServiceId { get; set; }
    }
}

using Base_Framework.Domain.Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture
{
    public class CreateHelpServicePictureDTO : PictureDTO
    {
        public IFormFile Picture { get; set; }
        public int HelpServiceId { get; set; }
    }
}

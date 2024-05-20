

using Base_Framework.Domain.Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture
{
    public class CreateHelpRequestPictureDTO : PictureDTO
    {
        public IFormFile Picture { get; set; }
        public int HelpRequestId { get; set; }
    }
}

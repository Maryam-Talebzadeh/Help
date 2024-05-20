using Base_Framework.Domain.Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Help.Domain.Core.AccountAgg.DTOs.CustomerPicture
{
    public class CreateCustomerPictureDTO : PictureDTO
    {
        public IFormFile Picture { get; set; }
        public int CustomerID { get; set; }
    }
}

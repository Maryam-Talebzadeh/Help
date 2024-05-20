using Base_Framework.Domain.Core.Attributes;
using Base_Framework.Domain.Core.DTOs;
using Base_Framework.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.AccountAgg.DTOs.CustomerPicture
{
    public class CreateCustomerPictureDTO : PictureDTO
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxFileSize(3 * 24, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        public IFormFile Picture { get; set; }
        public int CustomerID { get; set; }
    }
}



using Base_Framework.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.AccountAgg.DTOs.Address
{
    public class CreateAddressDTO
    {
        public string? Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int CityId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StreetName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int AlleyNumber { get; set; }
    }
}

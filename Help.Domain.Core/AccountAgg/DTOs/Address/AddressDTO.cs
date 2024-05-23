

using Help.Domain.Core.AccountAgg.DTOs.City;

namespace Help.Domain.Core.AccountAgg.DTOs.Address
{
    public class AddressDTO : EditAddressDTO
    {
        public CityDTO City { get; set; }
    }
}

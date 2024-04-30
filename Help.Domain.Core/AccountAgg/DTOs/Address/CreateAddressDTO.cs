

namespace Help.Domain.Core.AccountAgg.DTOs.Address
{
    public class CreateAddressDTO
    {
        public string Description { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; }
        public int AlleyNumber { get; set; }
    }
}



namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        public Int64 CardNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Bio { get; private set; }
        public long PictureId { get; private set; }
        public DateTime Birthday { get; private set; }
        public long AddressId { get; private set; }
    }
}

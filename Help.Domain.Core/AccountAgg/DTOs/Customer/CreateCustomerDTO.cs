

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int64 CardNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public long PictureId { get; set; }
        public string Birthday { get; set; }
        public long AddressId { get; set; }
    }
}

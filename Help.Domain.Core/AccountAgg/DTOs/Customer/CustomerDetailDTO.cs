using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class CustomerDetailDTO : EditCustomerDTO
    {
        public CustomerPictureDTO Profile { get; set; }
        public AddressDTO Address { get; set; }
    }
}

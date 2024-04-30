using Base_Framework.Domain.Core.DTOs;

namespace Help.Domain.Core.AccountAgg.DTOs.CustomerPicture
{
    public class CreateCustomerPictureDTO : PictureDTO
    {
        public int CustomerID { get; set; }
    }
}

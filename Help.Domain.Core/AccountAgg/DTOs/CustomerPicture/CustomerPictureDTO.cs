using Base_Framework.Domain.Core.DTOs;

namespace Help.Domain.Core.AccountAgg.DTOs.CustomerPicture
{
    public class CustomerPictureDTO : PictureDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsRejected { get; set; }
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerPictureRepository : IRepository<CustomerPicture>
    {
        void Create(CreateCustomerPictureDTO command);
        void Edit(EditCustomerPictureDTO command);
    }
}

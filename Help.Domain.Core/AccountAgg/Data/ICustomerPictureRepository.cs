using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerPictureRepository : IRepository<CustomerPicture>
    {
        Task<int> Create(CreateCustomerPictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken);
    }
}

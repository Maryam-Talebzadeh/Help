using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerPictureRepository : IRepository<CustomerPicture>
    {
        Task<int> Create(CreateCustomerPictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken);
        Task<EditCustomerPictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<CustomerPictureDTO> GetByCustomerId(int customerId, CancellationToken cancellationToken);
        Task<List<CustomerPictureDTO>> SearchUnConfirmed(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken);
        Task<List<CustomerPictureDTO>> Serach(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken);
        Task Confirm(int id, CancellationToken cancellationToken);
        Task Reject(int id, CancellationToken cancellationToken);
    }
}

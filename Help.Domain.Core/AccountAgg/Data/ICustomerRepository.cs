using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<int> Create(CreateCustomerDTO command, CancellationToken cancellationToken);
        Task Edit(EditCustomerDTO command, CancellationToken cancellationToken);
        Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken);
        Task Active(int id, CancellationToken cancellationToken);
        Task DeActive(int id, CancellationToken cancellationToken);
        Task ChangePassword(ChangeCustomerPasswordDTO changePasswordModel, CancellationToken cancellationToken);
        Task<string> GetUserNameById(int id, CancellationToken cancellationToken);
    }
}

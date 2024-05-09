using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Create(CreateCustomerDTO command, CancellationToken cancellationToken);
        Task Edit(EditCustomerDTO command, CancellationToken cancellationToken);
        Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken);
        Task Active(int id, CancellationToken cancellationToken);
    }
}

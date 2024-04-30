using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Create(CreateCustomerDTO command);
        void Edit(EditCustomerDTO command);
        CustomerDetailDTO GetDetails(int id);
        List<CustomerDTO> Search(SearchCustomerDTO searchModel);
        void Active(int id);
    }
}

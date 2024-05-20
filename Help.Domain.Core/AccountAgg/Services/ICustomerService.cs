using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Customer;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface ICustomerService
    {
        Task<OperationResult> Create(CreateCustomerDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCustomerDTO command, CancellationToken cancellationToken);
        Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> Active(int id, CancellationToken cancellationToken);
        Task<OperationResult> DeActive(int id, CancellationToken cancellationToken);
        Task<OperationResult> ChangePassword(ChangeCustomerPasswordDTO changePasswordModel, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
    }
}

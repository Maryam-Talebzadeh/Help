using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface ICustomerPictureService
    {
        Task<OperationResult> CreateDefault(CreateCustomerPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<EditCustomerPictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<CustomerPictureDTO> GetByCustomerId(int customerId, CancellationToken cancellationToken);
        Task<List<CustomerPictureDTO>> SearchUnChecked(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken);
        Task<List<CustomerPictureDTO>> Search(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(int id, CancellationToken cancellationToken);
        Task<OperationResult> Reject(int id, CancellationToken cancellationToken);
        Task<OperationResult> EditDefaultProfile(EditCustomerPictureDTO command, CancellationToken cancellationToken);

    }
}

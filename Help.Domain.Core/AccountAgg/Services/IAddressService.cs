using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Address;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface IAddressService
    {
        Task<OperationResult> Edit(EditAddressDTO command, CancellationToken cancellationToken);
        Task<EditAddressDTO> GetDetails(int id, CancellationToken cancellationToken);
    }
}

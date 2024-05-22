using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Admin;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface IAdminService
    {
        Task<OperationResult> Create(CreateAdminDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditAdminDTO command, CancellationToken cancellationToken);
        Task<EditAdminDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<AdminDTO>> Search(SearchAdminDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> ChangePassword(ChangeAdminPasswordDTO changePasswordModel, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
    }
}

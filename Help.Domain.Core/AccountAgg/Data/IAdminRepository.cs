using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Admin;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<int> Create(CreateAdminDTO command, CancellationToken cancellationToken);
        Task Edit(EditAdminDTO command, CancellationToken cancellationToken);
        Task<EditAdminDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<AdminDTO>> Search(SearchAdminDTO searchModel, CancellationToken cancellationToken);
        Task ChangePassword(ChangeAdminPasswordDTO changePasswordModel, CancellationToken cancellationToken);
    }
}

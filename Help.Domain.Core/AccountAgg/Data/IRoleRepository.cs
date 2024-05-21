using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Help.Domain.Core.AccountAgg.Entities;
namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
    }
}

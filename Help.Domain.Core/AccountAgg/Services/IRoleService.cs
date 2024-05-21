﻿using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Role;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface IRoleService
    {
        Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
    }
}

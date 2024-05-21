using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Services.AccountAgg;

namespace Help.Domain.AppServices.AccountAgg
{
    public class RoleAppService : IRoleAppService
    {

        private readonly IRoleService _roleService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(RoleAppService).Namespace;
        private readonly Type _type = new RoleDTO().GetType();

        public RoleAppService(IRoleService roleService, IOperationResultLogging operationResultLogging)
        {
            _roleService = roleService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = await _roleService.Create(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
           

        }

        public async Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = await _roleService.Edit(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }

                return operation;
            
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _roleService.GetAll(cancellationToken);
        }

        public async Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _roleService.GetDetails(id, cancellationToken);
        }
    }
}

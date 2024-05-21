using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly Type _type = new RoleDTO().GetType();

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _roleRepository.Create(command, cancellationToken);
                await _roleRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _roleRepository.IsExist(r => r.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (await _roleRepository.IsExist(r => r.Title == command.Title && r.Id != command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);           

            await _roleRepository.Edit(command, cancellationToken);
            await _roleRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _roleRepository.GetAll(cancellationToken);
        }

        public async Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetDetails(id, cancellationToken);
        }
    }
}

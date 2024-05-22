using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Admin;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Services.AccountAgg;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Help.Domain.AppServices.AccountAgg
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IAdminService _AdminService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(AdminAppService).Namespace;
        private readonly Type _type = new AdminDTO().GetType();

        public AdminAppService(IAdminService AdminService, IOperationResultLogging operationResultLogging)
        {
            _AdminService = AdminService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> ChangePassword(ChangeAdminPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            
               var operation = await _AdminService.ChangePassword(changePasswordModel, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(ChangePassword), _nameSpace, cancellationToken);
                return operation;
            }

                return operation;
            
        }

        public async Task<OperationResult> Create(CreateAdminDTO command, CancellationToken cancellationToken)
        {
            var operation = await _AdminService.Create(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<OperationResult> Edit(EditAdminDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _AdminService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _AdminService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<EditAdminDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _AdminService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = await _AdminService.Remove(id, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

        public async Task<List<AdminDTO>> Search(SearchAdminDTO searchModel, CancellationToken cancellationToken)
        {
            return await _AdminService.Search(searchModel, cancellationToken);
        }
    }
}

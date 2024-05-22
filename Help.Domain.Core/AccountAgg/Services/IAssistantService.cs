using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Assistant;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface IAssistantService
    {
        Task<OperationResult> Create(CreateAssistantDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditAssistantDTO command, CancellationToken cancellationToken);
        Task<EditAssistantDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<AssistantDTO>> Search(SearchAssistantDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> ChangePassword(ChangeAssistantPasswordDTO changePasswordModel, CancellationToken cancellationToken);
    }
}

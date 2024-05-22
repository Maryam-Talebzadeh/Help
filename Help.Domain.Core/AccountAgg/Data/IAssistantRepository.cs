using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Assistant;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IAssistantRepository : IRepository<Assistant>
    {
        Task<int> Create(CreateAssistantDTO command, CancellationToken cancellationToken);
        Task Edit(EditAssistantDTO command, CancellationToken cancellationToken);
        Task<EditAssistantDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<AssistantDTO>> Search(SearchAssistantDTO searchModel, CancellationToken cancellationToken);
        Task ChangePassword(ChangeAssistantPasswordDTO changePasswordModel, CancellationToken cancellationToken);
    }
}

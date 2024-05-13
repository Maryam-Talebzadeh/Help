using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IHelpServiceAppService
    {
        Task<OperationResult> Create(CreateHelpServiceDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpServiceDTO command, CancellationToken cancellationToken);
        Task<EditHelpServiceDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> Search(SearchHelpServiceDTO searchModel, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(int id, CancellationToken cancellationToken);
    }
}

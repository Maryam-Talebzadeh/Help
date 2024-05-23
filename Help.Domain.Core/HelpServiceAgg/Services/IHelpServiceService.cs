using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpServiceService
    {
        Task<OperationResult> Create(CreateHelpServiceDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpServiceDTO command, CancellationToken cancellationToken);
        Task<HelpServiceDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> Search(List<HelpServiceDTO> searchList, SearchHelpServiceDTO searchModel, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> GetAll(CancellationToken cancellationToken); //For Cache
    }
}

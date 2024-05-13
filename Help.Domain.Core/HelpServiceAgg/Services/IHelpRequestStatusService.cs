using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestStatus;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpRequestStatusService
    {
        Task<OperationResult> Create(CreateHelpRequestStatusDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpRequestStatusDTO command, CancellationToken cancellationToken);
        Task<List<HelpRequestStatusDTO>> GetAll( CancellationToken cancellationToken);
        Task<EditHelpRequestStatusDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(int id, CancellationToken cancellationToken);
    }
}

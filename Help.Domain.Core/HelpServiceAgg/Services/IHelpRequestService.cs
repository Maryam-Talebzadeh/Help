using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpRequestService
    {
        Task<OperationResult<HelpRequestDTO>> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> Edit(EditHelpRequestDTO command, CancellationToken cancellationToken);
        Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken);
        Task<int> Count(CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> Remove(int id, int adminCode, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> Confirm(int id, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> Reject(int id, int adminCode, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> ChangeStatus(int helpRequestId, int customerId, int statusId, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestDTO>> Done(int helpRequestId, int customerId, CancellationToken cancellationToken);
        Task<List<HelpRequestDTO>> GetAllUnConfirmed(CancellationToken cancellation);

    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpRequestRepository : IRepository<HelpRequest>
    {
        Task Create(CreateHelpRequestDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpRequestDTO command, CancellationToken cancellationToken);
        Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken);
        Task Confirm(int id, CancellationToken cancellation);
        Task Reject(int id, CancellationToken cancellation);
        Task ChangeStatus(int HelpRequestId, int statusId, CancellationToken cancellation);
        Task Done(int id, CancellationToken cancellation);
        Task<List<HelpRequestDTO>> SearchInUnChecked(SearchHelpRequestDTO searchModel, CancellationToken cancellation);
        Task<List<HelpRequestDTO>> SearchInRejected(SearchHelpRequestDTO searchModel, CancellationToken cancellation);
        Task<List<HelpRequestDTO>> GetAllConfirmed(SearchHelpRequestDTO searchModel, CancellationToken cancellation);
    }
}

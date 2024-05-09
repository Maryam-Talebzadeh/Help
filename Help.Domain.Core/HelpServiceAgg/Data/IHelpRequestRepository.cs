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
    }
}

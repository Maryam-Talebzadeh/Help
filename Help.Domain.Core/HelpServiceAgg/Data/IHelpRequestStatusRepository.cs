using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestStatus;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpRequestStatusRepository : IRepository<HelpRequestStatus>
    {
        Task Create(CreateHelpRequestStatusDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpRequestStatusDTO command, CancellationToken cancellationToken);
        Task<List<HelpRequestStatusDTO>> GetAll( CancellationToken cancellationToken);
        Task<EditHelpRequestStatusDTO> GetDetails(int id, CancellationToken cancellationToken);
    }
}

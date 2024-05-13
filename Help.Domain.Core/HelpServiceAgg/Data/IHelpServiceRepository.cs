using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServiceRepository : IRepository<HelpService>
    {
        Task Create(CreateHelpServiceDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpServiceDTO command, CancellationToken cancellationToken);
        Task<EditHelpServiceDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken);
        Task<List<HelpServiceDTO>> GetAll(CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpRequestPictureRepository : IRepository<HelpRequestPicture>
    {
        Task<int> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken);
        Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(int helpRequestId, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(CancellationToken cancellationToken);
    }
}

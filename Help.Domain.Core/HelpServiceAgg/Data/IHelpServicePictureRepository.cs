using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServicePictureRepository : IRepository<HelpServicePicture>
    {
        Task<int> Create(CreateHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpRequestPictureRepository : IRepository<HelpRequestPicture>
    {
        Task<int> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServicePictureRepository : IRepository<ServicePicture>
    {
        void CreateParent(CreateHelpServicePictureDTO command);
        void Edit(EditHelpServicePictureDTO command);
    }
}

using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
   public interface IHelpServicePictureService
    {
        Task<OperationResult> CreateDefault(CreateHelpServicePictureDTO command, CancellationToken cancellationToken);
         Task<OperationResult> EditDefaultPicture(EditHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<HelpServicePictureDTO> GetByHelpServiceId(int HelpServiceId, CancellationToken cancellationToken);     
    }
}

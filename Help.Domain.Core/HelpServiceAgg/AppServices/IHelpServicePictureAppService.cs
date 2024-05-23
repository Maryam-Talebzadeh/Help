using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IHelpServicePictureAppService
    {
        Task<OperationResult> EditDefaultPicture(EditHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<HelpServicePictureDTO> GetByHelpServiceId(int HelpServiceId, CancellationToken cancellationToken);
        Task<OperationResult> EditDefaultProfile(EditHelpServicePictureDTO command, CancellationToken cancellationToken);
    }
}

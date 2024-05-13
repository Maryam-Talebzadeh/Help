using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpRequestPictureService
    {
        Task<OperationResult> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> SearchUnConfirmed(int helpRequestId, CancellationToken cancellationToken);
    }
}

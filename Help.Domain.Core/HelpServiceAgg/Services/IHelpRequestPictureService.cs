﻿using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpRequestPictureService
    {
        Task<OperationResult<HelpRequestPictureDTO>> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestPictureDTO>> Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult<HelpRequestPictureDTO>> Remove(int id, CancellationToken cancellationToken);
        Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(int helpRequestId, CancellationToken cancellationToken);
        Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(CancellationToken cancellationToken);
    }
}

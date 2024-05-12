﻿using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IHelpServicePictureAppService
    {
        Task<OperationResult> Create(CreateHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken);
    }
}

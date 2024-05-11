﻿using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IHelpRequestAppService
    {
        Task<OperationResult> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpRequestDTO command, CancellationToken cancellationToken);
        Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken);
        Task<int> Count(CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(int id, CancellationToken cancellationToken);
        Task<OperationResult> Reject(int id, CancellationToken cancellationToken);
        Task<OperationResult> ChangeStatus(int helpRequestId, int customerId, int statusId, CancellationToken cancellationToken);
        Task<OperationResult> Done(int helpRequestId, int customerId, CancellationToken cancellationToken);
        Task<List<HelpRequestDTO>> SearchInUnConfirmed(SearchHelpRequestDTO searchModel, CancellationToken cancellation);

    }
}
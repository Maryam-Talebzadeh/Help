using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Vote;

namespace Help.Domain.Core.AccountAgg.AppServices
{
    public interface IVoteAppService
    {
        Task<OperationResult> Add(CreateVoteDTO command, CancellationToken cancellationToken);
        Task<Int16> GetRateAsExpert(int receiverId, CancellationToken cancellationToken);
        Task<Int16> GetRateAsRequester(int receiverId, CancellationToken cancellationToken);
        Task<List<VoteDTO>> GetBy(int requestId, CancellationToken cancellationToken);
        Task<VoteDTO> GetByvoterId(int requestId, int voterId, CancellationToken cancellationToken);
        Task<VoteDTO> GetByreceiverId(int requestId, int receiverId, CancellationToken cancellationToken);
        Task<bool> IsExist(int helpRequestId, int VoterId, CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.DTOs.Vote;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IVoteRepository : IRepository<Vote>
    {
        Task Add(CreateVoteDTO command, CancellationToken cancellationToken);
        Task<List<VoteDTO>> GetAllAsExpert(int receiverId, CancellationToken cancellationToken);
        Task<List<VoteDTO>> GetAllAsRequester(int receiverId, CancellationToken cancellationToken);
        Task<List<VoteDTO>> GetBy(int requestId,  CancellationToken cancellationToken);
        Task<VoteDTO> GetByvoterId(int requestId, int voterId, CancellationToken cancellationToken);
        Task<VoteDTO> GetByreceiverId(int requestId, int receiverId, CancellationToken cancellationToken);
    }
}

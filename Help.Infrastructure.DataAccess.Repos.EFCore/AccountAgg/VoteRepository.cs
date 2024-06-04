using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Vote;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class VoteRepository : BaseRepository_EFCore<Vote>, IVoteRepository
    {
        private readonly HelpContext _context;

        public VoteRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Add(CreateVoteDTO command, CancellationToken cancellationToken)
        {
            var vote = new Vote(command.VoterId, command.ReceiverId, command.HelpRequestId, command.Rate, command.Mode);
            _context.Votes.Add(vote);
        }

        public async Task<List<VoteDTO>> GetAllAsExpert(int receiverId, CancellationToken cancellationToken)
        {
            return _context.Votes.Where(v => v.ReceiverId == receiverId && v.Mode == 1)
                 .Select(v =>
                 new VoteDTO
                 {
                     Id = v.Id,
                     HelpRequestId = v.HelpRequestId,
                     ReceiverId = v.ReceiverId,
                     VoterId = v.VoterId,
                     Mode = v.Mode,
                     Rate = v.Rate
                 }).ToList();
        }

        public async Task<List<VoteDTO>> GetAllAsRequester(int receiverId, CancellationToken cancellationToken)
        {
            return _context.Votes.Where(v => v.ReceiverId == receiverId && v.Mode == 2)
                  .Select(v =>
                  new VoteDTO
                  {
                      Id = v.Id,
                      HelpRequestId = v.HelpRequestId,
                      ReceiverId = v.ReceiverId,
                      VoterId = v.VoterId,
                      Mode = v.Mode,
                      Rate = v.Rate
                  }).ToList();
        }

        public async Task<List<VoteDTO>> GetBy(int requestId, CancellationToken cancellationToken)
        {
            return _context.Votes.Where(v => v.HelpRequestId == requestId)
                  .Select(v =>
                  new VoteDTO
                  {
                      Id = v.Id,
                      HelpRequestId = v.HelpRequestId,
                      ReceiverId = v.ReceiverId,
                      VoterId = v.VoterId,
                      Mode = v.Mode,
                      Rate = v.Rate
                  }).ToList(); throw new NotImplementedException();
        }

        public async Task<VoteDTO> GetByreceiverId(int requestId, int receiverId, CancellationToken cancellationToken)
        {
            return _context.Votes.Where(v => v.HelpRequestId == requestId && v.ReceiverId == receiverId)
                   .Select(v =>
                   new VoteDTO
                   {
                       Id = v.Id,
                       HelpRequestId = v.HelpRequestId,
                       ReceiverId = v.ReceiverId,
                       VoterId = v.VoterId,
                       Mode = v.Mode,
                       Rate = v.Rate
                   }).FirstOrDefault();
        }

        public async Task<VoteDTO> GetByvoterId(int requestId, int voterId, CancellationToken cancellationToken)
        {
            return _context.Votes.Where(v => v.HelpRequestId == requestId && v.VoterId == voterId)
                  .Select(v =>
                  new VoteDTO
                  {
                      Id = v.Id,
                      HelpRequestId = v.HelpRequestId,
                      ReceiverId = v.ReceiverId,
                      VoterId = v.VoterId,
                      Mode = v.Mode,
                      Rate = v.Rate
                  }).FirstOrDefault();
        }
    }
}

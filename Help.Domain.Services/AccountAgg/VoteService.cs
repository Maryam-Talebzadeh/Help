using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Vote;
using Help.Domain.Core.AccountAgg.Services;
using System.Threading;

namespace Help.Domain.Services.AccountAgg
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly Type _type = new VoteDTO().GetType();

        public VoteService(IVoteRepository voteRepository, ICustomerRepository customerRepository)
        {
            _voteRepository = voteRepository;
            _customerRepository = customerRepository;
        }

        public async Task<OperationResult> Add(CreateVoteDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            if (!await _customerRepository.IsExist(c => c.Id == command.VoterId, cancellationToken))
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (!await _customerRepository.IsExist(c => c.Id == command.ReceiverId, cancellationToken))
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            await _voteRepository.Add(command, cancellationToken);
            await _voteRepository.Save(cancellationToken);
            return operation.Succedded();
        }

       

        public async Task<List<VoteDTO>> GetBy(int requestId, CancellationToken cancellationToken)
        {
            return await _voteRepository.GetBy(requestId, cancellationToken);
        }

        public async Task<VoteDTO> GetByreceiverId(int requestId, int receiverId, CancellationToken cancellationToken)
        {
            return await _voteRepository.GetByreceiverId(requestId,receiverId, cancellationToken);
        }

        public async Task<VoteDTO> GetByvoterId(int requestId, int voterId, CancellationToken cancellationToken)
        {
            return await _voteRepository.GetByvoterId(requestId, voterId, cancellationToken);
        }

        public async Task<short> GetRateAsExpert(int receiverId, CancellationToken cancellationToken)
        {
            var votes = await _voteRepository.GetAllAsExpert(receiverId, cancellationToken);
            if (votes.Count == 0)
                return 0;

            short sum = 0;
            short average;

            foreach(var vote in votes)
            {
                sum += vote.Rate;
            }

            average = (short)(sum / votes.Count);
            return average;
        }

        public async Task<short> GetRateAsRequester(int receiverId, CancellationToken cancellationToken)
        {
            var votes = await _voteRepository.GetAllAsRequester(receiverId, cancellationToken);
            if (votes.Count == 0)
                return 0;

            short sum = 0;
            short average;

            foreach (var vote in votes)
            {
                sum += vote.Rate;
            }

            average = (short)(sum / votes.Count);
            return average;
        }

        public async Task<bool> IsExist(int helpRequestId, int VoterId, CancellationToken cancellationToken)
        {
            return await _voteRepository.IsExist(v => v.HelpRequestId == helpRequestId && v.VoterId == VoterId, cancellationToken);
        }
    } 
}

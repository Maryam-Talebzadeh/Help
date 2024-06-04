using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Vote;
using Help.Domain.Core.AccountAgg.Services;
using Help.Domain.Services.AccountAgg;

namespace Help.Domain.AppServices.AccountAgg
{
    public class VoteAppService : IVoteAppService
    {
        private readonly IVoteService _voteService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(VoteAppService).Namespace;
        private readonly Type _type = new VoteDTO().GetType();


        public VoteAppService(IVoteService voteService, IOperationResultLogging operationResultLogging)
        {
            _voteService = voteService;
            _operationResultLogging = operationResultLogging;
        }

        public async Task<OperationResult> Add(CreateVoteDTO command, CancellationToken cancellationToken)
        {
            var operation = await _voteService.Add(command, cancellationToken);

            if (!operation.IsSuccedded)
            {
                _operationResultLogging.LogOperationResult(operation, nameof(Add), _nameSpace, cancellationToken);
                return operation;
            }

            return operation;
        }

    

        public async Task<List<VoteDTO>> GetBy(int requestId, CancellationToken cancellationToken)
        {
            var detail = await _voteService.GetBy(requestId, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, requestId);
                _operationResultLogging.LogOperationResult(operation, nameof(GetBy), _nameSpace, cancellationToken);
            }

            return await _voteService.GetBy(requestId, cancellationToken);
        }

        public async Task<VoteDTO> GetByreceiverId(int requestId, int receiverId, CancellationToken cancellationToken)
        {
            var detail = await _voteService.GetByreceiverId(requestId,receiverId, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, requestId);
                _operationResultLogging.LogOperationResult(operation, nameof(GetByreceiverId), _nameSpace, cancellationToken);
            }

           return await _voteService.GetByreceiverId(requestId, receiverId, cancellationToken);
        }

        public async Task<VoteDTO> GetByvoterId(int requestId, int voterId, CancellationToken cancellationToken)
        {
            var detail = await _voteService.GetByvoterId(requestId, voterId, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, requestId);
                _operationResultLogging.LogOperationResult(operation, nameof(GetByvoterId), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<short> GetRateAsExpert(int receiverId, CancellationToken cancellationToken)
        {
            return await _voteService.GetRateAsExpert(receiverId, cancellationToken);
        }

        public async Task<short> GetRateAsRequester(int receiverId, CancellationToken cancellationToken)
        {
            return await _voteService.GetRateAsRequester(receiverId, cancellationToken);
        }

        public async Task<bool> IsExist(int helpRequestId, int VoterId, CancellationToken cancellationToken)
        {
           return await _voteService.IsExist(helpRequestId, VoterId, cancellationToken);
        }
    }
}

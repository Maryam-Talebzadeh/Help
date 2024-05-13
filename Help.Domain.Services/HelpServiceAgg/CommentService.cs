using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly Type _type = new CommentDTO().GetType();

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _commentRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Confirm(id, cancellationToken);
            await _commentRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Create(CreateCommentDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _commentRepository.Create(command, cancellationToken);
                await _commentRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditCommentDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _commentRepository.IsExist(s => s.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Edit(command, cancellationToken);
            await _commentRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<CommentDTO>> SearchUnConfirmed(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            return await _commentRepository.SearchUnConfirmed(searchModel, cancellationToken);
        }

        public async Task<List<CommentDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task<CommentDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _commentRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Reject(id, cancellationToken);
            await _commentRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _commentRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Remove(id, cancellationToken);
            await _commentRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            return await _commentRepository.Search(searchModel, cancellationToken);
        }
    }
}

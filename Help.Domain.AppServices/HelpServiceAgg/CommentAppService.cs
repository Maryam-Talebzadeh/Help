using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly string _nameSpace = typeof(CommentAppService).Namespace;
        private readonly Type _type = new HelpRequestDTO().GetType();

        public CommentAppService(ICommentService commentService, IOperationResultLogging operationResultLogging, IHelpRequestPictureService helpRequestPictureService)
        {
            _commentService = commentService;
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _commentService.Confirm(id, cancellationToken);
            }
            catch
            {
                var operation = await _commentService.Confirm(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Confirm), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Create(CreateCommentDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _commentService.Create(command, cancellationToken);
            }
            catch
            {
                var operation = await _commentService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditCommentDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _commentService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _commentService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<CommentDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return await _commentService.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task<CommentDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _commentService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _commentService.Reject(id, cancellationToken);
            }
            catch
            {
                var operation = await _commentService.Reject(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Reject), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _commentService.Remove(id, cancellationToken);
            }
            catch
            {
                var operation = await _commentService.Remove(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Remove), _nameSpace, cancellationToken);
                return operation;
            }
        }
    

        public async Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
        return await _commentService.Search(searchModel, cancellationToken);
    }

        public async Task<List<CommentDTO>> SearchUnConfirmed(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            return await _commentService.SearchUnConfirmed(searchModel, cancellationToken);
        }
    }
}

using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface ICommentService
    {
        Task<OperationResult> Create(CreateCommentDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCommentDTO command, CancellationToken cancellationToken);
        Task<EditCommentDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(int id, CancellationToken cancellationToken);
        Task<OperationResult> Reject(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> SearchInUnChecked(SearchCommentDTO searchModel, CancellationToken cancellation);
        Task<List<CommentDTO>> SearchInRejected(SearchCommentDTO searchModel, CancellationToken cancellation);
    }
}

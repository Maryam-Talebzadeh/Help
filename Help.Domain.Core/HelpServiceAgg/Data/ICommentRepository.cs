using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.Entities;


namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task Create(CreateCommentDTO command, CancellationToken cancellationToken);
        Task Edit(EditCommentDTO command, CancellationToken cancellationToken);
        Task<EditCommentDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
        Task Confirm(int id, CancellationToken cancellationToken);
        Task Reject(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken);
        Task<List<CommentDTO>> SearchInUnChecked(SearchCommentDTO searchModel, CancellationToken cancellation);
        Task<List<CommentDTO>> SearchInRejected(SearchCommentDTO searchModel, CancellationToken cancellation);
    }
}

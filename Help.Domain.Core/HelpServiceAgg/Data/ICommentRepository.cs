using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.Entities;


namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task Create(CreateCommentDTO command, CancellationToken cancellationToken);
        Task Edit(EditCommentDTO command, CancellationToken cancellationToken);
        Task<CommentDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
        Task<List<CommentDTO>> GetAllUnConfirmed(SearchCommentDTO searchModel, CancellationToken cancellationToken);
        Task Confirm(int id, CancellationToken cancellationToken);
    }
}

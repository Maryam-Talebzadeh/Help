using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.Entities;


namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Create(CreateCommentDTO command);
        void Edit(EditCommentDTO command);
        CommentDetailDTO GetDetails(int id);
        List<CommentDTO> Search(SearchCommentDTO searchModel);
        List<CommentDTO> GetAllUnConfirmed(SearchCommentDTO searchModel);
        void Confirm(int id);
    }
}

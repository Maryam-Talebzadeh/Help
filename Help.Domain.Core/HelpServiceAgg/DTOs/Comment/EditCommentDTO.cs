

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class EditCommentDTO : CreateCommentDTO
    {
        public int Id { get; set; }
        public CommentDTO Parent { get; set; }
        public List<CommentDTO> Children { get; set; }
    }
}

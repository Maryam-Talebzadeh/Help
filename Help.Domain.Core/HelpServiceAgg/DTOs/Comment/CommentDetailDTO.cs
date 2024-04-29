

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CommentDetailDTO : EditCommentDTO
    {
        public CommentDTO Parent { get; set; }
        public List<CommentDTO> Children { get; set; }
    }
}

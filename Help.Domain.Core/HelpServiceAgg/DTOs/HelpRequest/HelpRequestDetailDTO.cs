

using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class HelpRequestDetailDTO : EditHelpRequestDTO
    {
        public List<CommentDTO> Comments { get; set; }
    }
}

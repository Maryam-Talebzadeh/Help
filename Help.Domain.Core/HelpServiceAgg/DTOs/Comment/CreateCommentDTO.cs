

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CreateCommentDTO
    {
        public int HelpRequestId { get; set; }
        public string Message { get; set; }
        public int? ParentId { get; set; }
        public int CustomerId { get; set; }
    }
}

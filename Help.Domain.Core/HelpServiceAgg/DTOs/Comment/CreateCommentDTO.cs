

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CreateCommentDTO
    {
        public long HelpRequestId { get; set; }
        public string Message { get; set; }
        public Int16 Score { get; set; }
        public long ParentId { get; set; }
        public long CustomerId { get; set; }
    }
}

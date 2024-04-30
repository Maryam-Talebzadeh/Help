

using Help.Domain.Core.AccountAgg.DTOs.Customer;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CommentDTO 
    {
        public long Id { get; set; }
        public long HelpRequestId { get; set; }
        public string Message { get; set; }
        public Int16 Score { get; set; }
        public string CreationDate { get; set; }
        public CustomerDTO Writer { get; set; }
        public CommentDTO Parent { get; set; }
        public List<CommentDTO> Children { get; set; }
    }
}



using Help.Domain.Core.AccountAgg.DTOs.Customer;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CommentDTO 
    {
        public int Id { get; set; }
        public int HelpRequestId { get; set; }
        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsRejected { get; set; }
        public string CreationDate { get; set; }
        public CustomerDTO Writer { get; set; }
        public CommentDTO Parent { get; set; }
        public List<CommentDTO> Children { get; set; }
    }
}

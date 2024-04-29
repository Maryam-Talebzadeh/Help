

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CommentDTO 
    {
        public long HelpRequestId { get; set; }
        public string Message { get; set; }
        public Int16 Score { get; set; }
        public CommentDTO parent { get; set; }
        public List<CommentDTO> Children { get; set; }
        public long CustomerRoleId { get; set; } //Temporary
    }
}

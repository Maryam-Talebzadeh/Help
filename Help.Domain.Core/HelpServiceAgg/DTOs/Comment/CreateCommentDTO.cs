

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Comment
{
    public class CreateCommentDTO
    {
        public long HelpRequestId { get; private set; }
        public string Message { get; private set; }
        public Int16 Score { get; private set; }
        public long ParentId { get; private set; }
        public long CustomerRoleId { get; private set; }
    }
}

using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(string message, Int16 score, int? parentId, int helpRequestId, int customerId)
        {
            Message = message; 
            Score = score; 
            ParentId = parentId;
            IsConfirmed = false;
            HelpRequestId = helpRequestId;
            CustomerId = customerId;
        }

        public int HelpRequestId { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public Int16 Score { get; private set; }
        public int? ParentId { get; private set; }
        public int CustomerId { get; private set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }
        public Customer Customer { get; set; }

        #endregion

        public void Edit(string message, Int16 score)
        {
            Message = message;
            Score = score;
            IsConfirmed = false;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Reject()
        {
            IsConfirmed = false;
        }

    }
}

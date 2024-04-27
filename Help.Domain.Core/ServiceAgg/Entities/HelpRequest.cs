using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;


namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class HelpRequest : BaseEntity
    {
        public HelpRequest(string title, string description, DateTime expirationDate, long customerId, long serviceId, double proposedPrice)
        {
            Title = title; 
            Description = description; 
            ExpirationDate = expirationDate; 
            CustomerId = customerId; 
            ServiceId = serviceId; 
            ProposedPrice = proposedPrice;
            IsDone = false;
            StatusId = 1;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsDone { get; private set; }
        public long StatusId { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public double ProposedPrice { get; private set; }

        #region Navigation Properties

        public HelpRequestStatus Status { get; private set; }
        public List<HelpRequestPicture> Pictures { get; private set; }
        public Service Service { get; private set; }
        public List<Proposal> Proposals { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string title, string description, DateTime expirationDate, long serviceId, double proposedPrice)
        {
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;
            ServiceId = serviceId;
            ProposedPrice = proposedPrice;
        }

        public void ChangeSatus(long statusId)
        {
            StatusId = statusId;
        }

        public void Done()
        {
            IsDone = true;
        }
    }
}

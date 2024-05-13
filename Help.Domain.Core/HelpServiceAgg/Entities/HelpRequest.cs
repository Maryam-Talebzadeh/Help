using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;


namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpRequest : BaseEntity
    {
        public HelpRequest(string title, string description, DateTime expirationDate, int customerId, int serviceId, double proposedPrice)
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
        public string Slug { get; private set; }
        public bool IsDone { get; private set; }
        public int StatusId { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsRejected { get; set; }
        public int CustomerId { get; private set; }
        public int ServiceId { get; private set; }
        public double ProposedPrice { get; private set; }

        #region Navigation Properties

        public HelpRequestStatus Status { get; private set; }
        public List<HelpRequestPicture> Pictures { get; private set; }
        public HelpService HelpService { get; private set; }
        public List<Proposal> Proposals { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string title, string description, DateTime expirationDate, int serviceId, double proposedPrice)
        {
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;
            ServiceId = serviceId;
            ProposedPrice = proposedPrice;
            IsConfirmed = false;
        }

        public void ChangeSatus(int statusId)
        {
            StatusId = statusId;
        }

        public void Done()
        {
            IsDone = true;
            StatusId = 4;
        }

        public void Confirm()
        {
            IsConfirmed = true;
            IsRejected = false;
        }

        public void Reject()
        {
            IsRejected = true;
            IsConfirmed = false;
        }
    }
}

using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string title, string? description, Int16 level, int serviceId, int customerId)
        {
            Title = title; 
            Description = description; 
            Level = level; 
            ServiceId = serviceId;
            CustomerId = customerId;
            IsConfirmed = false;

        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Int16 Level { get; private set; }
        public bool IsConfirmed { get; private set; }
        public int ServiceId { get; private set; }
        public int CustomerId { get; private set; }

        #region Navigation Properties

        public HelpService HelpService { get; private set; }
        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string title, string description, Int16 level, int serviceId)
        {
            Title = title;
            Description = description;
            Level = level;
            ServiceId = serviceId;
            IsConfirmed = false;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}

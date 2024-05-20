using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerPicture : Picture
    {
        public CustomerPicture(string name, string title, string alt, int customerId) : base(name, title, alt)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; private set; }
        public bool IsConfirmed { get; protected set; }

        #region Navigation Properties

        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
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

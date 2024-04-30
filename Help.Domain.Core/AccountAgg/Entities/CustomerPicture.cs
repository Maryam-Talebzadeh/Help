using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerPicture : Picture
    {
        public CustomerPicture(string name, string title, string alt, int customerId) : base(name, title, alt)
        {
            
        }

        public int CustomerId { get; private set; }

        #region Navigation Properties

        public Customer Customer { get; private set; }

        #endregion
    }
}

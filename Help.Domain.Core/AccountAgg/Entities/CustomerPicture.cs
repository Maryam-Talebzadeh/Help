

using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerPicture : Picture
    {
        public CustomerPicture(string name, string title, string alt, long customerId) : base(name, title, alt)
        {
            
        }

        public long CustomerId { get; private set; }
    }
}

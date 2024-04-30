using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;


namespace Help.Domain.Core.WalletAgg.Entities
{
    public class Wallet : BaseEntity
    {
        public Wallet(int customerId)
        {
            CustomerId = customerId;
        }

        public double Balance { get; private set; }
        public int CustomerId  { get; private set; }

        #region Navigation Properties

        public List<WalletOperation> Operations { get; private set; }
        public Customer Customer { get; private set; }

        #endregion
    }
}

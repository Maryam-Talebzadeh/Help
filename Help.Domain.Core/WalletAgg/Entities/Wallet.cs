using Base_Framework.Domain.Core.Entities;


namespace Help.Domain.Core.WalletAgg.Entities
{
    public class Wallet : BaseEntity
    {
        public Wallet(long customerId)
        {
            CustomerId = customerId;
        }

        public double Balance { get; private set; }
        public long CustomerId  { get; private set; }

        #region Navigation Properties

        public List<WalletOperation> Operations { get; private set; }

        #endregion
    }
}

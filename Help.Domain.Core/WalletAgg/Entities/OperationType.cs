

namespace Help.Domain.Core.WalletAgg.Entities
{
    public class OperationType
    {
        public long Id { get; private set; }
        public string Title { get; private set; }

        #region Navigation Properties

        public List<WalletOperation> Operations { get; private set; }

        #endregion
    }
}

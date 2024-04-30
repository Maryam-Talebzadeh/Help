

namespace Help.Domain.Core.WalletAgg.Entities
{
    public class OperationType
    {
        public OperationType( string title)
        {
            Title = title;
        }

        public byte Id { get; set; }
        public string Title { get; private set; }

        #region Navigation Properties

        public List<WalletOperation> Operations { get; private set; }

        #endregion
    }
}



namespace Help.Domain.Core.WalletAgg.DTOs.WalletOperation
{
    public class WalletOperationDTO
    {
        public long Id { get; set; }
        public double Amount { get; private set; }
        public string Type { get; private set; }
    }
}

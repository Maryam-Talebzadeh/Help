

namespace Help.Domain.Core.WalletAgg.DTOs.WalletOperation
{
    public class CreateWalleOperationtDTO
    {
        public double Amount { get; private set; }
        public long WalletId { get; private set; }
        public byte TypeId { get; private set; }
    }
}



namespace Help.Domain.Core.WalletAgg.DTOs.Wallet
{
   public class EditWalletDTO : CreateWalletDTO
    {
        public long Id { get; set; }
        public double Balance { get; set; }
    }
}

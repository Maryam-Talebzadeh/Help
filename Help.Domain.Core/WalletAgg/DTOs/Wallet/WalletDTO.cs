

using Help.Domain.Core.WalletAgg.DTOs.WalletOperation;

namespace Help.Domain.Core.WalletAgg.DTOs.Wallet
{
    public class WalletDTO 
    {
        public long Id { get; set; }
        public double Balance { get; set; }
        public List<WalletOperationDTO> Operations { get; set; }
    }
}

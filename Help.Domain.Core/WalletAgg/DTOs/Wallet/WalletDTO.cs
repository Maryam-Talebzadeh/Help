

namespace Help.Domain.Core.WalletAgg.DTOs.Wallet
{
    public class WalletDTO 
    {
        public long Id { get; set; }
        public double Balance { get; set; }
        public List<string> Operations { get; set; } //Temporary
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.WalletAgg.DTOs.Wallet;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.WalletAgg.Data
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        void Create(CreateWalletDTO command);
        void Edit(EditWalletDTO command);
        List<WalletDTO> GetBy(long customerId); 
    }
}

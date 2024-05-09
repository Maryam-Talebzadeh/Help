using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.WalletAgg.DTOs.Wallet;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.WalletAgg.Data
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Task Create(CreateWalletDTO command, CancellationToken cancellationToken);
        Task<List<WalletDTO>> GetBy(int customerId, CancellationToken cancellationToken); 
    }
}

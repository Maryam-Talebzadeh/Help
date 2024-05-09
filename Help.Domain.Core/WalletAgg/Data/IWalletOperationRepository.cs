using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.WalletAgg.DTOs.WalletOperation;
using Help.Domain.Core.WalletAgg.Entities;

namespace Help.Domain.Core.WalletAgg.Data
{
    public interface IWalletOperationRepository : IRepository<WalletOperation>
    {
        Task Create(CreateWalleOperationtDTO command, CancellationToken cancellationToken);
        Task<List<WalletOperationDTO>> GetBy(int walletId, CancellationToken cancellationToken);
        Task Cancel(int id, CancellationToken cancellationToken);
        Task finalize(int id, CancellationToken cancellationToken);
    }
}

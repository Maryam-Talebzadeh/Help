using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.WalletAgg.Data;
using Help.Domain.Core.WalletAgg.DTOs.WalletOperation;
using Help.Domain.Core.WalletAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.WalletAgg
{
    public class WalletOperationRepository : BaseRepository_EFCore<WalletOperation>, IWalletOperationRepository
    {
        private readonly HelpContext _context;

        public WalletOperationRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Cancel(int id, CancellationToken cancellationToken)
        {
            var operation = Get(id);
            operation.Cancel();
        }

        public async Task Create(CreateWalleOperationtDTO command, CancellationToken cancellationToken)
        {
            var operation = new WalletOperation(command.Amount, command.WalletId, command.TypeId);
            _context.WalletOperations.Add(operation);
        }

        public async Task finalize(int id, CancellationToken cancellationToken)
        {
            var operation = Get(id);
            operation.Finalize();
        }

        public async Task<List<WalletOperationDTO>> GetBy(int walletId, CancellationToken cancellationToken)
        {
            return _context.WalletOperations.Where(o => o.WalletId == walletId)
                .Select(o =>
                new WalletOperationDTO()
                {
                    Amount = o.Amount,
                    Id =o.Id,
                    Type = o.Type.Title
                }).ToList();
        }
    }
}

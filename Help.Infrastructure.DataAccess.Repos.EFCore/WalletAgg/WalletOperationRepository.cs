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

        public void Cancel(long id)
        {
            var operation = Get(id);
            operation.Cancel();
        }

        public void Create(CreateWalleOperationtDTO command)
        {
            var operation = new WalletOperation(command.Amount, command.WalletId, command.TypeId);
            _context.WalletOperations.Add(operation);
        }

        public void finalize(long id)
        {
            var operation = Get(id);
            operation.Finalize();
        }

        public List<WalletOperationDTO> GetBy(long walletId)
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

using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.WalletAgg.Data;
using Help.Domain.Core.WalletAgg.DTOs.Wallet;
using Help.Domain.Core.WalletAgg.DTOs.WalletOperation;
using Help.Domain.Core.WalletAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.WalletAgg
{
    public class WalletRepository : BaseRepository_EFCore<Wallet>, IWalletRepository
    {
        private readonly HelpContext _context;

        public WalletRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateWalletDTO command)
        {
            var wallet = new Wallet(command.CustomerId);
            _context.Wallets.Add(wallet);
        }

        public List<WalletDTO> GetBy(long customerId)
        {
            return _context.Wallets.Where(w => w.CustomerId == customerId)
                 .Select(w =>
                 new WalletDTO()
                 {
                     Id = w.Id,
                     Balance = w.Balance,
                     Operations = w.Operations.Select(o =>
                      new WalletOperationDTO()
                      {
                          Amount = o.Amount,
                          Id = o.Id,
                          Type = o.Type.Title
                      }).ToList()
                 }).ToList();
        }
    }
}

using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HelpContext _context;

        public AccountRepository(HelpContext context)
        {
            _context = context;
        }

        public async Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken)
        {
            var user = new AccountDTO();

            if (_context.Customers.Any(c => c.UserName == userName))
                return _context.Customers.Select(c =>
                new AccountDTO()
                {
                   Id = c.Id,
                   UserName = c.UserName,
                    FullName = c.FullName,
                   RoleId = c.RoleId,
                   Password = c.Password,
                   Mobile = c.Mobile
                }).FirstOrDefault(c => c.UserName == userName);

                return _context.Admins.Select(c =>
                new AccountDTO()
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    FullName = c.FullName,
                    RoleId = c.RoleId,
                    Password = c.Password,
                    Mobile = c.Mobile
                }).FirstOrDefault(c => c.UserName == userName);
        }

        public async Task<bool> IsExist(string userName, CancellationToken cancellationToken)
        {
            var res = _context.Customers.Any(c => c.UserName == userName);

            if(res == false)
            {
                 res = _context.Admins.Any(c => c.UserName == userName);
            }

            return res;

        }

        public async Task<bool> Login(LoginDTO login, CancellationToken cancellationToken)
        {
            bool res = _context.Customers.Any(c => c.UserName == login.UserName && c.Password == login.Password);

            if (res == null)
            {
                 res = _context.Admins.Any(c => c.UserName == login.UserName && c.Password == login.Password);
            }

            return res;
        }
    }
}

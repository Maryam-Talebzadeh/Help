using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.AppServices.AccountAgg
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountService _accountService;

        public AccountAppService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken)
        {
            return await _accountService.GetBy(userName, cancellationToken);
        }

        public async Task<bool> IsExist(string userName, CancellationToken cancellationToken)
        {
            return await _accountService.IsExist(userName, cancellationToken);
        }

        public async Task<OperationResult> Login(LoginDTO login, CancellationToken cancellationToken)
        {
            return await _accountService.Login(login, cancellationToken);
        }

        public async Task Logout(CancellationToken cancellationToken)
        {
             await _accountService.Logout(cancellationToken);
        }
    }
}
using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Core.DTOs;
using Base_Framework.Domain.Services;
using Base_Framework.General.Hashing;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly Type _type = new AccountDTO().GetType();

        public AccountService(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public async Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetBy(userName, cancellationToken);
        }

        public async Task<bool> IsExist(string userName, CancellationToken cancellationToken)
        {
            return await _accountRepository.IsExist(userName, cancellationToken);
        }

        public async Task<OperationResult> Login(LoginDTO login, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type,0);

            if(await IsExist(login.UserName, cancellationToken))
            {
                return operation.Failed(ApplicationMessages.WrongUserName);
            }

            var account = await GetBy(login.UserName, cancellationToken);
            operation.RecordReferenceId = account.Id;
            var result = _passwordHasher.Check(account.Password, login.Password);

            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongPassword);

            var authViewModel = new AuthDTO(account.Id, account.RoleId, account.FullName
               , account.UserName, account.Mobile);

            _authHelper.Signin(authViewModel);

            return operation.Succedded();
        }
    }
}

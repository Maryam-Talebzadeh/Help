using Help.Domain.Core.AccountAgg.DTOs.Account;

namespace Help.Domain.Core.AccountAgg.Data
{
    public interface IAccountRepository
    {
        Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken);
        Task<bool> Login(LoginDTO login, CancellationToken cancellationToken);
        Task<bool> IsExist(string userName, CancellationToken cancellationToken);
    }
}

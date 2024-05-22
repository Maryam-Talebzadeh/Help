using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Account;

namespace Help.Domain.Core.AccountAgg.AppServices
{
    public interface IAccountAppService
    {
        Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken);
        Task<OperationResult> Login(LoginDTO login, CancellationToken cancellationToken);
        Task<bool> IsExist(string userName, CancellationToken cancellationToken);
    }
}

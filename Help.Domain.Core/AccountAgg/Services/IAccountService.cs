using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Domain.Core.AccountAgg.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetBy(string userName, CancellationToken cancellationToken);
        Task<OperationResult> Login(LoginDTO login, CancellationToken cancellationToken);
        Task<bool> IsExist(string userName, CancellationToken cancellationToken);
    }
}

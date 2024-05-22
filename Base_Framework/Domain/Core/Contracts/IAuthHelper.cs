using Base_Framework.Domain.Core.DTOs;

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthDTO account);
        string CurrentAccountRole();
        AuthDTO CurrentAccountInfo();
        long CurrentAccountId();
        string CurrentAccountMobile();
    }
}

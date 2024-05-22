using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class AccountModel : PageModel
    {

        public string LoginMessage { get; set; }

        public string RegisterMessage { get; set; }


        private readonly IAccountAppService _accountAppService;
        private readonly ICustomerAppService _customerAppService;

        public AccountModel(IAccountAppService accountAppService, ICustomerAppService customerAppService)
        {
            _accountAppService = accountAppService;
            _customerAppService = customerAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(LoginDTO command, CancellationToken cancellationToken)
        {
            var result = await _accountAppService.Login(command, cancellationToken);

            if (result.IsSuccedded)
                return RedirectToPage("/Index");

            LoginMessage = result.Message;
            return Page();
        }

        public async Task<IActionResult> OnGetLogout(CancellationToken cancellationToken)
        {
           await _accountAppService.Logout(cancellationToken);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostRegister(CreateCustomerDTO command, CancellationToken cancellationToken)
        {
            var result = await _customerAppService.Register(command, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("/Account");
            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
    }
}

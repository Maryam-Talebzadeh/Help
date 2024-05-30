using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Account;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Help.EndPoints.RazorPage.Pages
{
    public class AccountModel : PageModel
    {
        public string Message { get; set; }
        public string SuccessRegisterMessage { get; set; }

        [BindProperty]
       public CreateCustomerDTO RegisterModel { get; set; }


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
            Message = result.Message;

            if (result.IsSuccedded)
                return RedirectToPage("/Index",new {message = Message });

            return Page();
        }

        public async Task<IActionResult> OnGetLogout(CancellationToken cancellationToken)
        {
           await _accountAppService.Logout(cancellationToken);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostRegister( CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _customerAppService.Register(RegisterModel, cancellationToken);
            if (result.IsSuccedded)
            {
                SuccessRegisterMessage = result.Message;
                return Page();
            }
            Message = result.Message;
            return Page();
        }
    }
}

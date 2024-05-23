using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        public ChangeCustomerPasswordDTO ChangePassword { get; set; } = new ChangeCustomerPasswordDTO();

        public string Message { get; set; }

        private readonly IAuthHelper _authHelper;
        private readonly ICustomerAppService _customerAppService;

        public ChangePasswordModel(IAuthHelper authHelper, ICustomerAppService customerAppService)
        {
            _authHelper = authHelper;
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
        {
            if (_authHelper.CurrentAccountId() != id)
                return Redirect("../../../AccessDenied");

            ChangePassword.Id = id;
;            return Page();
        }

        public async Task<IActionResult> OnPost( CancellationToken cancellationToken)
        {
            var result = await _customerAppService.ChangePassword(ChangePassword, cancellationToken);
            Message = result.Message;

            if(!result.IsSuccedded)
            {
                return Page();
            }

            return Page();
        }
    }
}

using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    [Authorize(Roles ="2")]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CustomerDetailDTO Customer { get; set; }

        private readonly IAuthHelper _authHelper;
        private readonly ICustomerAppService _customerAppService;

        public IndexModel(IAuthHelper authHelper, ICustomerAppService customerAppService)
        {
            _authHelper = authHelper;
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
        {
            if (_authHelper.CurrentAccountId() != id)
                return RedirectToPage("../../../AccessDenied");

            Customer = await _customerAppService.GetDetails(id, cancellationToken);
            return Page();
        }

        public async Task<IActionResult> OnPostEdit( CancellationToken cancellationToken)
        {
            var result = await _customerAppService.Edit(Customer, cancellationToken);
            return RedirectToPage("/Index");
        }

      
    }
}

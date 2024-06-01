using Base_Framework.Domain.Core.Contracts;
using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
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
        public List<HelpServiceDTO> HelpServices { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }

        private readonly IAuthHelper _authHelper;
        private readonly ICustomerAppService _customerAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IHelpServiceAppService _helpServiceAppService;

        public IndexModel(IAuthHelper authHelper, ICustomerAppService customerAppService, IHelpRequestAppService helpRequestAppService, IHelpServiceAppService helpServiceAppService)
        {
            _authHelper = authHelper;
            _customerAppService = customerAppService;
            _helpRequestAppService = helpRequestAppService;
            _helpServiceAppService = helpServiceAppService;
        }

        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken, string? message, string? icon)
        {
            Message = message;
            Icon = icon;
            HelpServices = await _helpServiceAppService.Search(new SearchHelpServiceDTO(), cancellationToken);

            if (_authHelper.CurrentAccountId() != id)
                return RedirectToPage("./AccessDenied");

            Customer = await _customerAppService.GetDetails(id, cancellationToken);
            return Page();
        }

        public async Task<IActionResult> OnPostEdit(List<int> HelpServicesIds, CancellationToken cancellationToken)
        {
            Customer.SkillIds = HelpServicesIds;
            var result = await _customerAppService.Edit(Customer, cancellationToken);
            
            HelpServices = await _helpServiceAppService.Search(new SearchHelpServiceDTO(), cancellationToken);
            Customer = await _customerAppService.GetDetails(Customer.Id, cancellationToken);
            return Page();
        }


        
    }
}

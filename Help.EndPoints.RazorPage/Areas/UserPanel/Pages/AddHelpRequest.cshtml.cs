using Base_Framework.Domain.Core.Contracts;
using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class AddHelpRequestModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public CreateHelpRequestDTO CreateHelpRequest { get; set; }
        public List<HelpServiceDTO> Services { get; set; }

        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IHelpServiceAppService _helpServiceAppService;
        private readonly IAuthHelper _authHelper;

        public AddHelpRequestModel(IHelpRequestAppService helpRequestAppService, IHelpServiceAppService helpServiceAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _helpServiceAppService = helpServiceAppService;
           _authHelper = authHelper;
        }

        public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
        {           
            Services = await _helpServiceAppService.Search(new Domain.Core.HelpServiceAgg.DTOs.HelpService.SearchHelpServiceDTO(), cancellationToken);
            return Page();
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            CreateHelpRequest.CustomerId = _authHelper.CurrentAccountId();

            var result = await _helpRequestAppService.Create(CreateHelpRequest, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                return Page();
            }
            
            return RedirectToPage("/Index");
        }
    }
}

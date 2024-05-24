using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class EditHelpRequestModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public EditHelpRequestDTO EditHelpRequest { get; set; }
        private readonly IHelpRequestAppService _helpRequestAppService;

        private readonly IHelpServiceAppService _helpServiceAppService;

        public EditHelpRequestModel(IHelpRequestAppService helpRequestAppService, IHelpServiceAppService helpServiceAppService)
        {
            _helpRequestAppService = helpRequestAppService;
                _helpServiceAppService = helpServiceAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            EditHelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            EditHelpRequest.Services = await _helpServiceAppService.Search(new SearchHelpServiceDTO(),cancellationToken);
        }

        public async Task<IActionResult> OnPost( CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _helpRequestAppService.Edit(EditHelpRequest, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                return Page();
            }

            return RedirectToPage("/HelpRequestList");
        }
    }
}

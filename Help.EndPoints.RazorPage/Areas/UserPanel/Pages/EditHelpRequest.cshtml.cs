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
        public string Icon { get; set; }
        public string Message { get; set; }
        [BindProperty]
        public EditHelpRequestDTO EditHelpRequest { get; set; }
        private readonly IHelpRequestAppService _helpRequestAppService;

        private readonly IAuthHelper _authHelper;
        private readonly IHelpServiceAppService _helpServiceAppService;

        public EditHelpRequestModel(IHelpRequestAppService helpRequestAppService, IHelpServiceAppService helpServiceAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
                _helpServiceAppService = helpServiceAppService;
            _authHelper = authHelper;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            EditHelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            EditHelpRequest.CustomerId = _authHelper.CurrentAccountId();
            EditHelpRequest.Services = await _helpServiceAppService.Search(new SearchHelpServiceDTO(),cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                EditHelpRequest.Services = await _helpServiceAppService.Search(new SearchHelpServiceDTO(), cancellationToken);
                return Page();
            }

            var result = await _helpRequestAppService.Edit(EditHelpRequest, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                return Page();
            }

            Icon = "success";

            return RedirectToPage("HelpRequestList", new { area = "userPanel", id = EditHelpRequest.CustomerId, message = Message, icon = Icon });
        }
    }
}

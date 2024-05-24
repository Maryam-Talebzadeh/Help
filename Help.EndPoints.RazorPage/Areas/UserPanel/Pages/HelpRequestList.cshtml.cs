using Base_Framework.Domain.Core.Contracts;
using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class HelpRequestListModel : PageModel
    {
        public List<HelpRequestDTO> RequestList { get; set; }
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IAuthHelper _authHelper;

        public HelpRequestListModel(IHelpRequestAppService helpRequestAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _authHelper = authHelper;
        }

        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
        {
            if(_authHelper.CurrentAccountId() != id)
            {
                return RedirectToPage("/AccessDenied");
            }

            var searchModel = new SearchHelpRequestDTO
            {
                CustomerId = id
            };

            RequestList = await _helpRequestAppService.Search(searchModel, cancellationToken);

            return Page();
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _helpRequestAppService.Remove(id, cancellationToken);

            var searchModel = new SearchHelpRequestDTO
            {
                CustomerId = id
            };

            RequestList = await _helpRequestAppService.Search(searchModel, cancellationToken);
        }
    }
}

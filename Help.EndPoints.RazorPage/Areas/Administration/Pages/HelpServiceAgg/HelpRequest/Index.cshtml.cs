using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.HelpServiceAgg.HelpRequest
{
    public class IndexModel : PageModel
    {
        private readonly IHelpRequestAppService _helpRequestAppService;

        public List<HelpRequestDTO> HelpRequests;
        public SearchHelpRequestDTO SearchModel;

        [TempData]
        public string Message { get; set; }

        public IndexModel(IHelpRequestAppService helpRequestAppService)
        {
            _helpRequestAppService = helpRequestAppService;
        }

        public async Task OnGet(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
           
            HelpRequests = await _helpRequestAppService.Search(searchModel, cancellationToken);
        }


        public async Task OnGetRejectedList(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
            HelpRequests = await _helpRequestAppService.SearchInRejected(searchModel, cancellationToken);
        }

        public async Task OnGetUnCheckedList(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {

            HelpRequests = await _helpRequestAppService.SearchInUnChecked(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetConfirm(int id, CancellationToken cancellationToken)
        {
            var result = await _helpRequestAppService.Confirm(id, cancellationToken);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

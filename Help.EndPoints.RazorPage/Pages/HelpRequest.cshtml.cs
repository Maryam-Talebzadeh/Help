using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class HelpRequestModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public CreateProposalDTO CreateProposal { get; set; }
        public EditHelpRequestDTO HelpRequest;

        private readonly IProposalAppService _proposalAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IAuthHelper _authHelper;


        public HelpRequestModel(IHelpRequestAppService helpRequestAppService, IProposalAppService proposalAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _proposalAppService = proposalAppService;
            _authHelper = authHelper;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CreateProposal.CustomerId = _authHelper.CurrentAccountId();

            var result = await _proposalAppService.Create(CreateProposal, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                return Page();
            }

            return RedirectToPage("Index", new { area ="UserPanel" ,id = _authHelper.CurrentAccountId() });
        }
    }
}

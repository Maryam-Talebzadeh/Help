using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace Help.EndPoints.RazorPage.Pages
{
    public class HelpRequestModel : PageModel
    {
        public string Message { get; set; }
        public string Icon { get; set; }
        [BindProperty]
        public CreateProposalDTO CreateProposal { get; set; }
        public HelpRequestDetailDTO HelpRequest;

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
            if(_authHelper.CurrentAccountId() == 0)
            {
                return RedirectToPage("./Account");
            }

            if (!ModelState.IsValid)
            {
                HelpRequest = await _helpRequestAppService.GetDetails(CreateProposal.HelpRequestId, cancellationToken);
                return Page();
            }
            CreateProposal.CustomerId = _authHelper.CurrentAccountId();

            var result = await _proposalAppService.Create(CreateProposal, cancellationToken);
            Message = result.Message;


            if (!result.IsSuccedded)
            {
                HelpRequest = await _helpRequestAppService.GetDetails(CreateProposal.HelpRequestId, cancellationToken);
                Icon = "error";
                return Page();

            }

            Icon = "success";
            return RedirectToPage("HelpRequestList", new { area = "userPanel", id = CreateProposal.CustomerId, message = Message, icon = Icon });
        }
    }
}

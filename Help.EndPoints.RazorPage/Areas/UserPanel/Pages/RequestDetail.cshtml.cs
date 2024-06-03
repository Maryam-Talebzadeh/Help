using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class RequestDetailModel : PageModel
    {
        public string Message { get; set; }
        public string Icon { get; set; }
        public List<ProposalDTO> Proposals { get; set; }
        public EditHelpRequestDTO HelpRequest;

        private readonly IProposalAppService _proposalAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IAuthHelper _authHelper;


        public RequestDetailModel(IHelpRequestAppService helpRequestAppService, IProposalAppService proposalAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _proposalAppService = proposalAppService;
            _authHelper = authHelper;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            var searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
        }

        public async Task<IActionResult> OnGetConfirm(int id, int helpRequestId, CancellationToken cancellationToken)
        {
            SearchProposaltDTO searchMedel;
            var result = await _proposalAppService.Confirm(id, helpRequestId, cancellationToken);

            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                return Page();

            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            return Page();

        }

        public async Task<IActionResult> OnGetDone(int id, CancellationToken cancellationToken)
        {

            SearchProposaltDTO searchMedel;
            var result = await _helpRequestAppService.Done(id, _authHelper.CurrentAccountId(),cancellationToken);

            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                return Page();
            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            return Page();

        }

    }
}

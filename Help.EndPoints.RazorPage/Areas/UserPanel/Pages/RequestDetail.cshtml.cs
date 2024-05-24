using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class RequestDetailModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
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

        public async Task OnGetConfirm(int id, CancellationToken cancellationToken)
        {
          var res = await _proposalAppService.Confirm(id, cancellationToken);

            if(res.IsSuccedded)
            {
                Message = res.Message;
            }

        }
    }
}

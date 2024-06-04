using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services.Authentication;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.EndPoints.RazorPage.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class ProposalListModel : PageModel
    {
        private readonly IProposalAppService _proposalAppService;
        private readonly IAuthHelper _authHelper;
        public List<ProposalDTO> Proposals { get; set; }

        public ProposalListModel(IProposalAppService proposalAppService, IAuthHelper authHelper)
        {
            _proposalAppService = proposalAppService;
            _authHelper = authHelper;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
          var  searchMedel = new SearchProposaltDTO()
            {
                CustomerId = _authHelper.CurrentAccountId()
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
        }
    }
}

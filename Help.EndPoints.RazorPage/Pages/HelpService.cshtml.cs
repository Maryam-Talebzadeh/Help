using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class HelpServiceModel : PageModel
    {
        public HelpServiceDetailDTO HelpService;
        private readonly IHelpServiceAppService _helpServiceAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;

        public HelpServiceModel(IHelpServiceAppService helpServiceAppService, IHelpRequestAppService helpRequestAppService)
        {
            _helpServiceAppService = helpServiceAppService;
            _helpRequestAppService = helpRequestAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            HelpService = await _helpServiceAppService.GetDetails(id, cancellationToken);
            var searchModel = new SearchHelpRequestDTO()
            {
                ServiceId = HelpService.Id
            };
            HelpService.HelpRequests = await _helpRequestAppService.GetAllConfirmed(searchModel, cancellationToken);
        }
    }
}

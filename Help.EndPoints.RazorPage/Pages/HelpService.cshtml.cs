using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class HelpServiceModel : PageModel
    {
        public HelpServiceDetailDTO HelpService;
        private readonly IHelpServiceAppService _helpServiceAppService;

        public HelpServiceModel(IHelpServiceAppService helpServiceAppService)
        {
            _helpServiceAppService = helpServiceAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            HelpService = await _helpServiceAppService.GetDetails(id, cancellationToken);
        }
    }
}

using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.ViewComponents
{
    public class HelpServicesViewComponent : ViewComponent
    {
        private readonly IHelpServiceAppService _helpServiceAppService;

        public HelpServicesViewComponent(IHelpServiceAppService helpServiceAppService)
        {
            _helpServiceAppService = helpServiceAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var helpServices = await _helpServiceAppService.Search(new SearchHelpServiceDTO(),cancellationToken);
            return View(helpServices);
        }
    }
}

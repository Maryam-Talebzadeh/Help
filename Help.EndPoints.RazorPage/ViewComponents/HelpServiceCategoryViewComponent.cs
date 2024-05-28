using Help.Domain.Core.HelpServiceAgg.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.ViewComponents
{
    public class HelpServiceCategoryViewComponent : ViewComponent
    {
        private readonly IHelpServiceCategoryAppService _helpServiceCategoryAppService;

        public HelpServiceCategoryViewComponent(IHelpServiceCategoryAppService helpServiceCategoryAppService)
        {
            _helpServiceCategoryAppService = helpServiceCategoryAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        
        {
            var categories = await _helpServiceCategoryAppService.GetAllParents(cancellationToken);
            return View(categories);
        }
    }
}

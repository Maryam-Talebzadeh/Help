using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class HelpServiceCategoryModel : PageModel
    {
        public List<HelpServiceCategoryDTO> Children {get; set;}
        public List<HelpServiceDTO> Services { get; set; }
        public HelpServiceCategoryDetailDTO Category { get; set; }
        private readonly IHelpServiceCategoryAppService _helpServiceCategoryAppService;
        private readonly IHelpServiceAppService _helpServiceAppService;

        public HelpServiceCategoryModel(IHelpServiceCategoryAppService helpServiceCategoryAppService, IHelpServiceAppService helpServiceAppService)
        {
            _helpServiceCategoryAppService = helpServiceCategoryAppService;
            _helpServiceAppService = helpServiceAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            Category = await _helpServiceCategoryAppService.GetDetails(id, cancellationToken);
            Children = await _helpServiceCategoryAppService.GetChildsByParentId(id, cancellationToken);
            var searchModel = new SearchHelpServiceDTO()
            {
                CategoryId = id
            };

            Services = await _helpServiceAppService.Search(searchModel, cancellationToken);
        }
    }
}

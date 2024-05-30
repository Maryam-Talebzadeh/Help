using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        public List<HelpServiceDTO> Services;
        private readonly IHelpServiceAppService _helpServiceAppService;

        public SearchModel(IHelpServiceAppService helpServiceAppService)
        {
            _helpServiceAppService = helpServiceAppService;
        }

        public async Task OnGet(string value, CancellationToken cancellationToken)
        {
            Value = value;
            var searchModel = new SearchHelpServiceDTO()
            {
                Title = value
            };
            Services = await _helpServiceAppService.Search(searchModel, cancellationToken);
        }
    }
}

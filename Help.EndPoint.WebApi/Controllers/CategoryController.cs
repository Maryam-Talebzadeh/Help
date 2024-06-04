using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.EndPoint.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoint.WebApi.Controllers
{
   
  
    public class CategoryController : ControllerBase
    {
        private readonly IHelpServiceCategoryAppService _helpServiceCategoryAppService;
        private readonly IHelpServiceAppService _helpServiceAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;

        public CategoryController(IHelpServiceAppService helpServiceAppService, IHelpRequestAppService helpRequestAppService, IHelpServiceCategoryAppService helpServiceCategoryAppService)
        {
            _helpServiceAppService = helpServiceAppService;
            _helpRequestAppService = helpRequestAppService;
            _helpServiceCategoryAppService = helpServiceCategoryAppService;
        }
        [HttpGet("GetAllWithServices")]
        public async Task<IActionResult> GetAllWithServices(CancellationToken cancellationToken)
        {
            var categories =await _helpServiceCategoryAppService.GetAllIdTitleDTO(cancellationToken);
            var res = new List<CategoryWithServicesDto>();
            foreach (var i in categories)
            {
              
                if (i.Id != null)
                {

                    var categoryDetail =await _helpServiceCategoryAppService.GetDetails(i.Id??0, cancellationToken);
                    var services =await _helpServiceAppService.Search(new SearchHelpServiceDTO() { CategoryId = i.Id ?? 0 },cancellationToken);
                    var category = new CategoryWithServicesDto()
                    {
                        Id = categoryDetail.Id,
                        Title = categoryDetail.Title,
                        Description = categoryDetail.Description,
                        ParentId = categoryDetail.ParentId,
                        Services = services
                    };
                    res.Add(category);
                }

            }
            return Ok(res);
        }
    }
}

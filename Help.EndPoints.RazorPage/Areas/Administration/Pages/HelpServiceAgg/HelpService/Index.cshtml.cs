using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.HelpServiceAgg.HelpService
{
    public class IndexModel : PageModel
    {
        private readonly IHelpServiceAppService _helpServiceAppService;
        private readonly IHelpServiceCategoryAppService _helpServiceCategoryAppService;
        private readonly IHelpServicePictureAppService _helpServicePictureAppService;

        public List<HelpServiceDTO> HelpServices;
        public SearchHelpServiceDTO SearchModel;
        public SelectList Categories;

        [TempData]
        public string Message { get; set; }

        public IndexModel(IHelpServiceAppService helpServiceAppService, IHelpServiceCategoryAppService helpServiceCategoryAppService, IHelpServicePictureAppService helpServicePictureAppService)
        {
            _helpServiceAppService = helpServiceAppService;
            _helpServiceCategoryAppService = helpServiceCategoryAppService;
            _helpServicePictureAppService = helpServicePictureAppService;

        }

        public async Task OnGet(SearchHelpServiceDTO searchModel, CancellationToken cancellationToken)
        {
            HelpServices = await _helpServiceAppService.Search(searchModel, cancellationToken);
        }

        public async Task<ActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new CreateHelpServiceDTO();
            command.Categories = await _helpServiceCategoryAppService.GetAllIdTitleDTO(cancellationToken);

            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(CreateHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var result =await _helpServiceAppService.Create(command, cancellationToken);

            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(int id, CancellationToken cancellationToken)
        {
            var helpService = await _helpServiceAppService.GetDetails(id, cancellationToken);
            helpService.Categories = await _helpServiceCategoryAppService.GetAllIdTitleDTO(cancellationToken);

            return Partial("Edit", helpService);
        }

        public async Task<JsonResult> OnPostEdit(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var result = _helpServiceAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _helpServiceAppService.Remove(id, cancellationToken);
            HelpServices = await _helpServiceAppService.Search(new SearchHelpServiceDTO(), cancellationToken);
        }

        public async Task<ActionResult> OnGetCreatePicture(int id, CancellationToken cancellationToken)
        {
            var command = new CreateHelpServicePictureDTO()
            {
                HelpServiceId = id
            };
           

            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostPicture(CreateHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var result = await _helpServicePictureAppService.Create(command, cancellationToken);

            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEditPicture(int id, CancellationToken cancellationToken)
        {
            var picture = await _helpServicePictureAppService.GetDetails(id, cancellationToken);

            return Partial("Edit", picture);
        }

        public async Task<JsonResult> OnPostEditPicture(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var result = await _helpServicePictureAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }
    }
}

using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.HelpServiceAgg.HelpServiceCategory
{
    public class IndexModel : PageModel
    {
        private readonly IHelpServiceCategoryAppService _helpServiceCategoryAppService;

        public List<HelpServiceCategoryDTO>? HelpServiceCategories;
        public SearchHelpServiceCategoryDTO SearchModel;

        [TempData]
        public string Message { get; set; }

        public IndexModel(IHelpServiceCategoryAppService helpServiceCategoryAppService)
        {
            _helpServiceCategoryAppService = helpServiceCategoryAppService;
        }

        public async Task OnGet(SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            HelpServiceCategories = await _helpServiceCategoryAppService.Search(searchModel, cancellationToken);
        }

        public async Task<ActionResult> OnGetCreateChild(int parentId, CancellationToken cancellationToken)
        {
            var command = new CreateChildHelpServiceCategoryDTO()
            {
                ParentId = parentId
            };

            return Partial("./CreateChild", command);
        }

        public async Task OnPostCreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _helpServiceCategoryAppService.CreateChild(command, cancellationToken);

            Message = result.Message;
        }

        public async Task<ActionResult> OnGetCreateParent(CancellationToken cancellationToken)
        {
            var command = new CreateParentHelpServiceCategoryDTO();

            return Partial("./CreateParent", command);
        }

        public async Task OnPostCreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _helpServiceCategoryAppService.CreateParent(command, cancellationToken);

            Message = result.Message;
        }

        public async Task<IActionResult> OnGetEdit(int id, CancellationToken cancellationToken)
        {
            var detail = await _helpServiceCategoryAppService.GetDetails(id, cancellationToken);

            var editModel = new EditHelpServiceCategoryDTO()
            {
                Id = detail.Id,
                Description = detail.Description,
                ParentId = detail.ParentId,
                Title = detail.Title
            };

            return Partial("Edit", editModel);
        }

        public async Task<JsonResult> OnPostEdit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var result = _helpServiceCategoryAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _helpServiceCategoryAppService.Remove(id, cancellationToken);
            HelpServiceCategories = await _helpServiceCategoryAppService.Search(new SearchHelpServiceCategoryDTO(), cancellationToken);
            Message = result.Message;
        }

        public async Task OnGetGetChilds(int parentId, CancellationToken cancellationToken)
        {
            HelpServiceCategories = await _helpServiceCategoryAppService.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task OnGetGetAllParents(int parentId, CancellationToken cancellationToken)
        {
            HelpServiceCategories = await _helpServiceCategoryAppService.GetAllParents(cancellationToken);
        }
    }
}

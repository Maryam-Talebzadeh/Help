using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.HelpServiceAgg.Comments
{
    public class IndexModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public List<CommentDTO> Comments;
        public SearchCommentDTO SearchModel;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        public async Task OnGet(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.SearchInUnChecked(searchModel, cancellationToken);
        }


        public async Task OnGetRejectedList(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.SearchInRejected(searchModel, cancellationToken);
        }
        public async Task OnGetUnCheckedList(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {

            Comments = await _commentAppService.SearchInUnChecked(searchModel, cancellationToken);
        }

        public async Task<ActionResult> OnGetCreateChild(int parentId, CancellationToken cancellationToken)
        {
            var command = new CreateCommentDTO()
            {
                ParentId = parentId
            };

            return Partial("./CreateChild", command);
        }

        public async Task OnPostCreateChild(CreateCommentDTO command, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Create(command, cancellationToken);

            Message = result.Message;
        }

        public async Task<ActionResult> OnGetCreateParent(CancellationToken cancellationToken)
        {
            var command = new CreateCommentDTO()
            {
                ParentId = null
            };

            return Partial("./CreateParent", command);
        }

        public async Task OnPostCreateParent(CreateCommentDTO command, CancellationToken cancellationToken)
        {
            command.CustomerId = 100;
            var result = await _commentAppService.Create(command, cancellationToken);

            Message = result.Message;
        }

        public async Task<IActionResult> OnGetEdit(int id, CancellationToken cancellationToken)
        {
            var comment = await _commentAppService.GetDetails(id, cancellationToken);
            return Partial("Edit", comment);
        }

        public async Task<JsonResult> OnPostEdit(EditCommentDTO command, CancellationToken cancellationToken)
        {
            var result = _commentAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Remove(id, cancellationToken);
            Comments = await _commentAppService.Search(new SearchCommentDTO(), cancellationToken);
            Message = result.Message;
        }

        public async Task OnGetGetChilds(int parentId, CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task<IActionResult> OnGetConfirm(int id, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Confirm(id, cancellationToken);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetReject(int id, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Reject(id, cancellationToken);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

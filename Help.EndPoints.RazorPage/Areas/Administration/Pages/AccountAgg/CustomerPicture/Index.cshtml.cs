using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.AccountAgg.CustomerPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchCustomerPictureDTO SearchModel;
        public List<CustomerPictureDTO> CustomerPictures;

        private readonly ICustomerPictureAppService _customerPictureAppService;
        public IndexModel(ICustomerPictureAppService customerPictureAppService)
        {
            _customerPictureAppService = customerPictureAppService;
        }

        public async Task OnGet(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            CustomerPictures = await _customerPictureAppService.Search(searchModel, cancellationToken);
        }

        public async Task OnGetSearchUnChecked(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            CustomerPictures = await _customerPictureAppService.SearchUnChecked(searchModel, cancellationToken);
        }

        public async Task OnGetConfirm(int id, CancellationToken cancellationToken)
        {
           await _customerPictureAppService.Confirm(id, cancellationToken);
            CustomerPictures = await _customerPictureAppService.Search(new SearchCustomerPictureDTO(), cancellationToken);
        }

        public async Task OnGetReject(int id, CancellationToken cancellationToken)
        {
           await _customerPictureAppService.Reject(id, cancellationToken);
            CustomerPictures = await _customerPictureAppService.Search(new SearchCustomerPictureDTO(), cancellationToken);
        }

        public async Task<IActionResult> OnGetEditDefault(int id , CancellationToken cancellationToken)
        {
            var picture = await _customerPictureAppService.GetDetails(id, cancellationToken);

            return Partial("EditDefault", picture);
        }

        public async Task<ActionResult> OnPostEditDefault(EditCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Partial("EditDefault", command);
            }

            var result = _customerPictureAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }
    }
}

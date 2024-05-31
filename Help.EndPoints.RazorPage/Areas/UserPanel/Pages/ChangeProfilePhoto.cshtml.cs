using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class ChangeProfilePhotoModel : PageModel
    {
        [BindProperty]
        public EditCustomerPictureDTO Profile { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }

        private readonly ICustomerPictureAppService _customerPictureAppService;

        public ChangeProfilePhotoModel(ICustomerPictureAppService customerPictureAppService)
        {
            _customerPictureAppService = customerPictureAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            Profile = await _customerPictureAppService.GetDetails(id, cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _customerPictureAppService.Edit(Profile, cancellationToken);

            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                return Page();

            }

            Icon = "success";
            return RedirectToPage("HelpRequestList", new { area = "userPanel", id = Profile.CustomerID, message = Message, icon = Icon });

        }
    }
}

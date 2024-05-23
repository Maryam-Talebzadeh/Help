using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        private readonly ICustomerPictureAppService _customerPictureAppService;

        private readonly IAuthHelper _authHelper;

        public SideMenuViewComponent(ICustomerPictureAppService customerPictureAppService, IAuthHelper authHelper)
        {
            _customerPictureAppService = customerPictureAppService;
            _authHelper = authHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var picture = await _customerPictureAppService.GetByCustomerId(_authHelper.CurrentAccountId(), cancellationToken);

            return View(picture);
        }
    }
}

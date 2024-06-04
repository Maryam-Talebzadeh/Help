using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.EndPoints.RazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        private readonly ICustomerPictureAppService _customerPictureAppService;

        private readonly IVoteAppService _voteAppService;

        private readonly IAuthHelper _authHelper;

        public SideMenuViewComponent(ICustomerPictureAppService customerPictureAppService, IAuthHelper authHelper, IVoteAppService voteAppService)
        {
            _customerPictureAppService = customerPictureAppService;
            _authHelper = authHelper;
            _voteAppService = voteAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var model = new SideMenuViewModel()
            {
                Picture = await _customerPictureAppService.GetByCustomerId(_authHelper.CurrentAccountId(), cancellationToken),
                RateAsExpert = await _voteAppService.GetRateAsExpert(_authHelper.CurrentAccountId(), cancellationToken),
                RateAsRequester = await _voteAppService.GetRateAsRequester(_authHelper.CurrentAccountId(), cancellationToken)
            };

            return View(model);
        }

        
        }
    }


using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.ViewComponents
{
    public class HelpRequestsViewComponent : ViewComponent
    {
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IAuthHelper _authHelper;

        public HelpRequestsViewComponent(IHelpRequestAppService helpRequestAppServic, ICustomerAppService customerAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppServic;
            _customerAppService = customerAppService;
            _authHelper = authHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            SearchHelpRequestDTO searchModel = new SearchHelpRequestDTO();

            if(_authHelper.IsAuthenticated())
            {

                searchModel.ServiceIds = await _customerAppService.GetSkillsId(_authHelper.CurrentAccountId(), cancellationToken);
                
            }
           
            var helpRequests = await _helpRequestAppService.Search(searchModel, cancellationToken);
            return View(helpRequests);
        }

    }
}

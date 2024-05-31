using Base_Framework.Domain.Core.Contracts;
using Base_Framework.General;
using Help.Domain.AppServices.HelpServiceAgg;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    [Authorize]
    public class AddHelpRequestModel : PageModel
    {
        public string Message { get; set; }
        public string Icon { get; set; }
        [BindProperty]
        public CreateHelpRequestDTO CreateHelpRequest { get; set; } 
        public List<HelpServiceDTO> Services { get; set; }

        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IHelpServiceAppService _helpServiceAppService;
        private readonly IAuthHelper _authHelper;

        public AddHelpRequestModel(IHelpRequestAppService helpRequestAppService, IHelpServiceAppService helpServiceAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _helpServiceAppService = helpServiceAppService;
           _authHelper = authHelper;
        }

        public async Task<IActionResult> OnGet(CancellationToken cancellationToken, int serviceId = 0)
        {
                CreateHelpRequest = new CreateHelpRequestDTO();

            CreateHelpRequest.CustomerId = _authHelper.CurrentAccountId();
            Services = await _helpServiceAppService.Search(new Domain.Core.HelpServiceAgg.DTOs.HelpService.SearchHelpServiceDTO(), cancellationToken);
            CreateHelpRequest.ServiceId = serviceId;
            return Page();
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
            {
                Services = await _helpServiceAppService.Search(new Domain.Core.HelpServiceAgg.DTOs.HelpService.SearchHelpServiceDTO(), cancellationToken);
                return Page();
            }               

            var result = await _helpRequestAppService.Create(CreateHelpRequest, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
               Icon = "error";
                return Page();
                
            }

            Icon= "success";
            return RedirectToPage("HelpRequestList", new {area = "userPanel",id= CreateHelpRequest.CustomerId, message = Message, icon = Icon });
        }
    }
}

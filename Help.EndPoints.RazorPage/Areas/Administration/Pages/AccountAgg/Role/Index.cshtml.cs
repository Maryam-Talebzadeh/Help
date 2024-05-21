using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.AccountAgg.Role
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<RoleDTO> Roles;

        private readonly IRoleAppService _roleAppService;

        public IndexModel(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Roles = await _roleAppService.GetAll(cancellationToken);
        }
    }
}

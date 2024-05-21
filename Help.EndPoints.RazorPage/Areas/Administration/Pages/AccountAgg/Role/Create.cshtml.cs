using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.AccountAgg.Role
{
    public class CreateModel : PageModel
    {
        public CreateRoleDTO Command;
        private readonly IRoleAppService _roleAppService;

        public CreateModel(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
    }



        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var result = await _roleAppService.Create(command, cancellationToken);
            return RedirectToPage("Index");
        }

    }
}

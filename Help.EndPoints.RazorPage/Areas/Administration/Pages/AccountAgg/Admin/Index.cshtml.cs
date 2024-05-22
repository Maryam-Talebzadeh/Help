using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.AccountAgg.Admin
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchAdminDTO SearchModel;
        public List<AdminDTO> Admins;
        public SelectList Roles;

        private readonly IAdminAppService _AdminAppservice;
        private readonly IRoleAppService _roleAppService;

        public IndexModel(IAdminAppService AdminAppservice, IRoleAppService roleAppService)
        {
            _AdminAppservice = AdminAppservice;
            _roleAppService = roleAppService;
        }

        public async Task OnGet(SearchAdminDTO searchModel, CancellationToken cancellationToken)
        {
            Admins = await _AdminAppservice.Search(searchModel, cancellationToken);
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _AdminAppservice.Remove(id, cancellationToken);
            Message = result.Message;
        }

        public async Task<IActionResult> OnGetCreate( CancellationToken cancellationToken)
        {
            var Admin = new CreateAdminDTO();


                Admin.Roles = await _roleAppService.GetAll(cancellationToken);
        
            return Partial("./Create", Admin);
        }

        public async Task OnPostRegister(CreateAdminDTO command, CancellationToken cancellationToken)
        {
            var result = await _AdminAppservice.Create(command, cancellationToken);
        }

        public async Task<IActionResult> OnGetEdit(int id, CancellationToken cancellationToken)
        {
            var account = await _AdminAppservice.GetDetails(id, cancellationToken);
            account.Roles = await _roleAppService.GetAll(cancellationToken);
            return Partial("Edit", account);
        }

        public async Task<IActionResult> OnPostEdit(EditAdminDTO command, CancellationToken cancellationToken)
        {
            var result = await _AdminAppservice.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

    }
}

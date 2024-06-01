using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.DTOs.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class EditAddressModel : PageModel
    {
        public string Icon { get; set; }
        public string Message { get; set; }
        [BindProperty]
        public EditAddressDTO EditAddress { get; set; }
        public List<CityDTO> Cities { get; set; }

        private readonly IAddressAppService _addressAppService;
        private readonly ICityAppService _cityAppService;

        public EditAddressModel(IAddressAppService addressAppService, ICityAppService cityAppService)
        {
            _addressAppService = addressAppService;
            _cityAppService = cityAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            EditAddress = await _addressAppService.GetDetails(id, cancellationToken);
            Cities = await _cityAppService.Search(new SearchCityDTO(), cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                Cities = await _cityAppService.Search(new SearchCityDTO(), cancellationToken);
                return Page();
            }

            var result = await _addressAppService.Edit(EditAddress, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Cities = await _cityAppService.Search(new SearchCityDTO(), cancellationToken);
                Icon = "error";
                return Page();
            }

            Icon = "success";

            return RedirectToPage("Index", new { area = "userPanel", id = EditAddress.CustomerId, message = Message, icon = Icon });
        }
    }
}

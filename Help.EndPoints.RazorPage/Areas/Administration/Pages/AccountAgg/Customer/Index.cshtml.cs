using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Help.EndPoints.RazorPage.Areas.Administration.Pages.AccountAgg.Customer
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchCustomerDTO SearchModel;
        public List<CustomerDTO> Customers;
        public SelectList Roles;

        private readonly ICustomerAppService _customerAppservice;

        public IndexModel(ICustomerAppService customerAppservice)
        {
            _customerAppservice = customerAppservice;
        }

        public async Task OnGet(SearchCustomerDTO searchModel, CancellationToken cancellationToken)
        {
            Customers = await _customerAppservice.Search(searchModel, cancellationToken);
        }

        public async Task OnGetRemove(int id, CancellationToken cancellationToken)
        {
            var result = await _customerAppservice.Remove(id, cancellationToken);
            Message = result.Message;
        }

        public async Task OnGetActivate(int id, CancellationToken cancellationToken)
        {
            var result = await _customerAppservice.Active(id, cancellationToken);
            Customers = await _customerAppservice.Search(new SearchCustomerDTO() , cancellationToken);
            Message = result.Message;
        }

        public async Task OnGetDeActive(int id, CancellationToken cancellationToken)
        {
            var result = await _customerAppservice.DeActive(id, cancellationToken);
            Customers = await _customerAppservice.Search(new SearchCustomerDTO(), cancellationToken);
            Message = result.Message;
        }
    }
}

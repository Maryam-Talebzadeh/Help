using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoint.WebApi.Controllers
{
    public class AcountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;
        private readonly ICustomerAppService _customerAppService;

        public AcountController(IAccountAppService accountAppService, ICustomerAppService customerAppService)
        {
            _accountAppService = accountAppService;
            _customerAppService = customerAppService;
        }
        [HttpPost("Register")]
        public async Task< IActionResult> Register(CreateCustomerDTO registerModel,CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.ValidationState);
                var result = await _customerAppService.Register(registerModel, cancellationToken);
                if (result.IsSuccedded)
                {

                    return Ok();
                }
                return BadRequest(result.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

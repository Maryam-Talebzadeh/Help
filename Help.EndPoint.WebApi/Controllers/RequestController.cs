using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoint.WebApi.Controllers
{
   
    
    public class RequestController : ControllerBase
    {
        private readonly IProposalAppService _proposalAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IAuthHelper _authHelper;


        public RequestController(IHelpRequestAppService helpRequestAppService, IProposalAppService proposalAppService, IAuthHelper authHelper)
        {
            _helpRequestAppService = helpRequestAppService;
            _proposalAppService = proposalAppService;
            _authHelper = authHelper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
        {
            var res = await _helpRequestAppService.GetAllConfirmed(new SearchHelpRequestDTO(), cancellationToken);
            return Ok(res);
        }

    }
}

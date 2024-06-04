using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Help.Domain.Core.AccountAgg.AppServices;
using Help.Domain.Core.AccountAgg.DTOs.Vote;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.Comment;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Help.EndPoints.RazorPage.Areas.UserPanel.Pages
{
    public class RequestDetailModel : PageModel
    {
        public string Message { get; set; }
        public string Icon { get; set; }
        public List<ProposalDTO> Proposals { get; set; }
        public HelpRequestDetailDTO HelpRequest;
        public ProposalDTO Proposal { get; set; }
        public List<CommentDTO> Comments;
        public bool HasVoted { get; set; }
        public Int16 Vote { get; set; }


        private readonly IProposalAppService _proposalAppService;
        private readonly IHelpRequestAppService _helpRequestAppService;
        private readonly IVoteAppService _voteAppService; 
        private readonly ICommentAppService _commentAppService;
        private readonly IAuthHelper _authHelper;


        public RequestDetailModel(IHelpRequestAppService helpRequestAppService, IProposalAppService proposalAppService, IAuthHelper authHelper, ICommentAppService commentAppService, IVoteAppService voteAppService)
        {
            _helpRequestAppService = helpRequestAppService;
            _proposalAppService = proposalAppService;
            _authHelper = authHelper;
            _commentAppService = commentAppService;
            _voteAppService = voteAppService;
        }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            if(HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }

            var commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);

            var searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if(HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
        }

        public async Task<IActionResult> OnGetConfirm(int id, int helpRequestId, CancellationToken cancellationToken)
        {
            SearchProposaltDTO searchMedel;
            var result = await _proposalAppService.Confirm(id, helpRequestId, cancellationToken);

            SearchCommentDTO commentSearchModel;

            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
                if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
                {
                    Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
                }
                commentSearchModel = new SearchCommentDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                if (HasVoted)
                {
                    var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                    Vote = res.Rate;
                }
                return Page();

            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
            if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }
            commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if (HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
            return Page();

        }

        public async Task<IActionResult> OnGetDone(int id, CancellationToken cancellationToken)
        {
            SearchCommentDTO commentSearchModel;
            SearchProposaltDTO searchMedel;
            var result = await _helpRequestAppService.Done(id, _authHelper.CurrentAccountId(),cancellationToken);

            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
                if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
                {
                    Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
                }
                commentSearchModel = new SearchCommentDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                if (HasVoted)
                {
                    var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                    Vote = res.Rate;
                }
                return Page();
            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(id, cancellationToken);
            if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }
            commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if (HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddVote(CreateVoteDTO votemodel, CancellationToken cancellationToken)
        {
            SearchProposaltDTO searchMedel;
            SearchCommentDTO commentSearchModel;
            votemodel.VoterId = _authHelper.CurrentAccountId();
            votemodel.Mode = 2;

            var result = await _voteAppService.Add(votemodel, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                HelpRequest = await _helpRequestAppService.GetDetails(votemodel.HelpRequestId, cancellationToken);
                if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
                {
                    Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
                }
                commentSearchModel = new SearchCommentDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                if (HasVoted)
                {
                    var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                    Vote = res.Rate;
                }
                return Page();
            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(votemodel.HelpRequestId, cancellationToken);
            if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }
            commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if (HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCreateChild(int? parentId,string message, int helpRequestId, CancellationToken cancellationToken)
        {
            SearchProposaltDTO searchMedel;
            SearchCommentDTO commentSearchModel;
            var command = new CreateCommentDTO()
            {
                ParentId = parentId,
                HelpRequestId = helpRequestId,
                CustomerId = _authHelper.CurrentAccountId(),
                Message = message
            };

            var result = await _commentAppService.Create(command, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
                if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
                {
                    Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
                }
                commentSearchModel = new SearchCommentDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                if (HasVoted)
                {
                    var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                    Vote = res.Rate;
                }
                return Page();
            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(helpRequestId, cancellationToken);
            if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }
            commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if (HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddComment(CreateCommentDTO command, CancellationToken cancellationToken)
        {

            SearchProposaltDTO searchMedel;
            SearchCommentDTO commentSearchModel;
            command.ParentId = null;
            command.CustomerId = _authHelper.CurrentAccountId();

            var result = await _commentAppService.Create(command, cancellationToken);
            Message = result.Message;

            if (!result.IsSuccedded)
            {
                Icon = "error";
                HelpRequest = await _helpRequestAppService.GetDetails(command.HelpRequestId, cancellationToken);
                if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
                {
                    Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
                }
                commentSearchModel = new SearchCommentDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
                searchMedel = new SearchProposaltDTO()
                {
                    HelpRequestId = HelpRequest.Id
                };
                Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
                HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                if (HasVoted)
                {
                    var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                    Vote = res.Rate;
                }
                return Page();
            }

            Icon = "success";
            HelpRequest = await _helpRequestAppService.GetDetails(command.HelpRequestId, cancellationToken);
            if (HelpRequest.StatusId == 4 || HelpRequest.StatusId == 5)
            {
                Proposal = await _proposalAppService.GetBy(HelpRequest.Id, cancellationToken);
            }
            commentSearchModel = new SearchCommentDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Comments = await _commentAppService.Search(commentSearchModel, cancellationToken);
            searchMedel = new SearchProposaltDTO()
            {
                HelpRequestId = HelpRequest.Id
            };
            Proposals = await _proposalAppService.Search(searchMedel, cancellationToken);
            HasVoted = await _voteAppService.IsExist(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
            if (HasVoted)
            {
                var res = await _voteAppService.GetByvoterId(HelpRequest.Id, _authHelper.CurrentAccountId(), cancellationToken);
                Vote = res.Rate;
            }
            return Page();
        }

        public async Task OnGetGetChilds(int parentId, CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetChildsByParentId(parentId, cancellationToken);
        }

    }
}

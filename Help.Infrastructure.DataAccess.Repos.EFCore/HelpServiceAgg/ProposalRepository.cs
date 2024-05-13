﻿using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.General;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.DTOs.Customer;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class ProposalRepository : BaseRepository_EFCore<Proposal>, IProposalRepository
    {
        private readonly HelpContext _context;

        public ProposalRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Confirm(int id, CancellationToken cancellationToken)
        {
            var proposal = Get(id);
            proposal.Confirm();
        }

        public async Task Create(CreateProposalDTO command, CancellationToken cancellationToken)
        {
            var proposal = new Proposal(command.Description, command.SuggestedTime.ToGregorianDateTime(), command.SuggestedPrice, command.HelpRequestId, command.CustomerId);
            _context.Proposals.Add(proposal);
        }

        public async Task Edit(EditProposalDTO command, CancellationToken cancellationToken)
        {
            var proposal = Get(command.Id);
            proposal.Edit(command.Description, command.SuggestedTime.ToGregorianDateTime(), command.SuggestedPrice);
        }

        public async Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Proposals.Where(p => !p.IsConfirmed).Select(p =>
            new ProposalDTO()
            {
               Id = p.Id,
               Description = p.Description,
               CreationDate = p.CreationDate.ToFarsi(),
               SuggestedPrice = p.SuggestedPrice,
               Customer = new CustomerDTO()
                {
                    Id = p.Customer.Id,
                    Picture = new CustomerPictureDTO()
                    {
                        Title = p.Customer.Profile.Title,
                        Name = p.Customer.Profile.Name,
                        Alt = p.Customer.Profile.Alt,
                        CustomerId = p.Customer.Id
                    }
                },
               HelpRequest = new HelpRequestDTO()
               {
                   Id = p.HelpRequest.Id,
                   Customer = new CustomerDTO()
                   {
                       Id = p.Customer.Id,
                       Picture = new CustomerPictureDTO()
                       {
                           Title = p.Customer.Profile.Title,
                           Name = p.Customer.Profile.Name,
                           Alt = p.Customer.Profile.Alt,
                           CustomerId = p.Customer.Id
                       }
                   },
                   Description = p.HelpRequest.Description,
                   Title = p.HelpRequest.Title,
                   ExpirationDate = p.HelpRequest.ExpirationDate.ToFarsi(),
                   HelpService = new IdTitleHelpServiceDTO()
                   {
                       Id = p.HelpRequest.HelpService.Id,
                       Title = p.HelpRequest.HelpService.Title
                   },
                   IsDone = p.HelpRequest.IsDone
               }
            });

            if (searchModel.HelpRequestId > 0)
                query = query.Where(p => p.HelpRequest.Id == searchModel.HelpRequestId);

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }

        public async Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Proposals.Select(p =>
            new EditProposalDTO()
            {
                Id = p.Id,
                Description = p.Description,
                SuggestedPrice = p.SuggestedPrice,
                CustomerId = p.CustomerId,
                HelpRequestId = p.HelpRequestId,
                SuggestedTime = p.SuggestedTime.ToFarsi()
            }).FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Proposals.Where(p => p.IsConfirmed).Select(p =>
            new ProposalDTO()
            {
                Id = p.Id,
                Description = p.Description,
                CreationDate = p.CreationDate.ToFarsi(),
                SuggestedPrice = p.SuggestedPrice,
                Customer = new CustomerDTO()
                {
                    Id = p.Customer.Id,
                    Picture = new CustomerPictureDTO()
                    {
                        Title = p.Customer.Profile.Title,
                        Name = p.Customer.Profile.Name,
                        Alt = p.Customer.Profile.Alt,
                        CustomerId = p.Customer.Id
                    }
                },
                HelpRequest = new HelpRequestDTO()
                {
                    Id = p.HelpRequest.Id,
                    Customer = new CustomerDTO()
                    {
                        Id = p.Customer.Id,
                        Picture = new CustomerPictureDTO()
                        {
                            Title = p.Customer.Profile.Title,
                            Name = p.Customer.Profile.Name,
                            Alt = p.Customer.Profile.Alt,
                            CustomerId = p.Customer.Id
                        }
                    },
                    Description = p.HelpRequest.Description,
                    Title = p.HelpRequest.Title,
                    ExpirationDate = p.HelpRequest.ExpirationDate.ToFarsi(),
                    HelpService = new IdTitleHelpServiceDTO()
                    {
                        Id = p.HelpRequest.HelpService.Id,
                        Title = p.HelpRequest.HelpService.Title
                    },
                    IsDone = p.HelpRequest.IsDone
                }
            });

            if (searchModel.HelpRequestId > 0)
                query = query.Where(p => p.HelpRequest.Id == searchModel.HelpRequestId);

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}

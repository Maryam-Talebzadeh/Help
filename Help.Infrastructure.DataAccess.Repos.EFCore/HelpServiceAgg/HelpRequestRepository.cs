using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpRequestRepository : BaseRepository_EFCore<HelpRequest>, IHelpRequestRepository
    {
        private readonly HelpContext _context;

        public HelpRequestRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeStatus(int helpRequestId, int statusId, CancellationToken cancellation)
        {
            var helpRequest = Get(helpRequestId);
            helpRequest.ChangeSatus(statusId);
        }

        public async Task Confirm(int id, CancellationToken cancellation)
        {
            var helpRequest = Get(id);
            helpRequest.Confirm();
        }

        public async Task<int> Create(CreateHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var helpRequest = new HelpRequest(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.CustomerId, command.ServiceId, command.ProposedPrice);
            _context.HelpRequests.Add(helpRequest);
           await Save(cancellationToken);
            return helpRequest.Id
;        }

        public async Task Done(int id, CancellationToken cancellation)
        {
            var helpRequest = Get(id);
            helpRequest.Done();
        }

        public async Task Edit(EditHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var helpRequest = Get(command.Id);
            helpRequest.Edit(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.ServiceId, command.ProposedPrice);
        }

        public async Task<List<HelpRequestDTO>> SearchInUnChecked(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            var query = _context.HelpRequests.Where(hr => hr.IsConfirmed == false && hr.IsRejected == false).Select(hr =>
           new HelpRequestDTO()
           {
               Id = hr.Id,
               Description = hr.Description,
               Title = hr.Title,
               IsDone = hr.IsDone,
               Status = hr.Status.Title,
               StatusId = hr.StatusId,
               IsConfirmed = hr.IsConfirmed,
               IsRejected = hr.IsRejected,
               CustomerId = hr.CustomerId,
               ExpirationDate = hr.ExpirationDate.ToDiscountFormat(),
               HelpService = new IdTitleHelpServiceDTO()
               {
                   Id = hr.HelpService.Id,
                   Title = hr.HelpService.Title
               },
               Customer = new CustomerDTO()
               {
                   Id = hr.Customer.Id,
                   Picture = new CustomerPictureDTO()
                   {
                       Title = hr.Customer.Profile.Title,
                       Name = hr.Customer.Profile.Name,
                       Alt = hr.Customer.Profile.Alt,
                       CustomerId = hr.Customer.Id
                   }
               }
           });

            if (!searchModel.Title.IsNullOrEmpty())
                query = query.Where(hr => hr.Title == searchModel.Title);

            if (!searchModel.ServiceName.IsNullOrEmpty())
                query = query.Where(hr => hr.HelpService.Title.Contains(searchModel.Title));

            if (searchModel.ServiceId > 0)
                query = query.Where(hr => hr.HelpService.Id == searchModel.ServiceId);

            if (searchModel.CustomerId > 0)
                query = query.Where(hr => hr.CustomerId == searchModel.CustomerId);

            return query.ToList();
        }

        public async Task<HelpRequestDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.HelpRequests.Select(hr =>
            new HelpRequestDetailDTO()
            {
                CustomerId = hr.Id,
                Description = hr.Description,
                ExpirationDate = hr.ExpirationDate.ToFarsi(),
                Id = hr.Id,
                Title = hr.Title,
                ProposedPrice = hr.ProposedPrice,
                ServiceId = hr.ServiceId,
                StatusId = hr.StatusId,
                IsDone = hr.IsDone,
                Customer = new CustomerDTO()
                {
                    Id = hr.Customer.Id,
                    FullName = hr.Customer.FullName,
                    Picture = new CustomerPictureDTO()
                    {
                        Name = hr.Customer.Profile.Name,
                        Alt = hr.Customer.Profile.Alt
                    }
                }

            }).FirstOrDefault(hr => hr.Id == id);
        }

        public async Task Reject(int id, CancellationToken cancellation)
        {
            var helpRequest = Get(id);
            helpRequest.Reject();
        }

        public async Task<List<HelpRequestDTO>> Search(SearchHelpRequestDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.HelpRequests.Select(hr =>
            new HelpRequestDTO()
            {
                Id = hr.Id,
                Description = hr.Description,
                Title = hr.Title,
                IsDone = hr.IsDone,
                Status = hr.Status.Title,
                StatusId = hr.StatusId,
                IsConfirmed = hr.IsConfirmed,
                CustomerId = hr.CustomerId,
                IsRejected = hr.IsRejected,
                ExpirationDate = hr.ExpirationDate.ToFarsi(),
                HelpService = new IdTitleHelpServiceDTO()
                {
                    Id = hr.HelpService.Id,
                    Title = hr.HelpService.Title
                },
                Customer = new CustomerDTO()
                {
                    Id = hr.Customer.Id,
                    FullName = hr.Customer.FullName,
                    Picture = new CustomerPictureDTO()
                    {
                        Title = hr.Customer.Profile.Title,
                        Name = hr.Customer.Profile.Name,
                        Alt = hr.Customer.Profile.Alt,
                        CustomerId = hr.Customer.Id
                    }
                },
            }) ;

            if (!searchModel.Title.IsNullOrEmpty())
                query = query.Where(hr => hr.Title == searchModel.Title);

            if (!searchModel.ServiceName.IsNullOrEmpty())
                query = query.Where(hr => hr.HelpService.Title.Contains(searchModel.Title));

            if (searchModel.ServiceId > 0)
                query = query.Where(hr => hr.HelpService.Id == searchModel.ServiceId);

            if (searchModel.CustomerId > 0)
                query = query.Where(hr => hr.CustomerId == searchModel.CustomerId);

            if (searchModel.ServiceIds.Count() > 0)
                query = query.Where(hr => searchModel.ServiceIds.Any(s => s == hr.HelpService.Id));

            return query.ToList();
        }

        public async Task<List<HelpRequestDTO>> SearchInRejected(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            var query = _context.HelpRequests.Where(hr => hr.IsRejected == true && hr.IsConfirmed == false).Select(hr =>
          new HelpRequestDTO()
          {
              Id = hr.Id,
              Description = hr.Description,
              Title = hr.Title,
              IsDone = hr.IsDone,
              Status = hr.Status.Title,
              StatusId = hr.StatusId,
              IsConfirmed = hr.IsConfirmed,
              CustomerId = hr.CustomerId,
              IsRejected = hr.IsRejected,
               ExpirationDate = hr.ExpirationDate.ToFarsi(),
              HelpService = new IdTitleHelpServiceDTO()
              {
                  Id = hr.HelpService.Id,
                  Title = hr.HelpService.Title
              },
              Customer = new CustomerDTO()
              {
                  Id = hr.Customer.Id,
                  Picture = new CustomerPictureDTO()
                  {
                      Title = hr.Customer.Profile.Title,
                      Name = hr.Customer.Profile.Name,
                      Alt = hr.Customer.Profile.Alt,
                      CustomerId = hr.Customer.Id
                  }
              }
          });

            if (!searchModel.Title.IsNullOrEmpty())
                query = query.Where(hr => hr.Title == searchModel.Title);

            if (!searchModel.ServiceName.IsNullOrEmpty())
                query = query.Where(hr => hr.HelpService.Title.Contains(searchModel.Title));

            if (searchModel.ServiceId > 0)
                query = query.Where(hr => hr.HelpService.Id == searchModel.ServiceId);

            if (searchModel.CustomerId > 0)
                query = query.Where(hr => hr.CustomerId == searchModel.CustomerId);

            return query.ToList();
        }

        public async Task<List<HelpRequestDTO>> GetAllConfirmed(SearchHelpRequestDTO searchModel, CancellationToken cancellation)
        {
            var query = _context.HelpRequests.Where(hr => hr.IsConfirmed == true)
          .Select(hr =>
      new HelpRequestDTO()
      {
          Id = hr.Id,
          Description = hr.Description,
          Title = hr.Title,
          IsDone = hr.IsDone,
          Status = hr.Status.Title,
          StatusId = hr.StatusId,
          IsConfirmed = hr.IsConfirmed,
          CustomerId = hr.CustomerId,
          IsRejected = hr.IsRejected,
          ExpirationDate = hr.ExpirationDate.ToFarsi(),
          HelpService = new IdTitleHelpServiceDTO()
          {
              Id = hr.HelpService.Id,
              Title = hr.HelpService.Title
          },
          Customer = new CustomerDTO()
          {
              Id = hr.Customer.Id,
              Picture = new CustomerPictureDTO()
              {
                  Title = hr.Customer.Profile.Title,
                  Name = hr.Customer.Profile.Name,
                  Alt = hr.Customer.Profile.Alt,
                  CustomerId = hr.Customer.Id
              }
          },
      });

            if (!searchModel.Title.IsNullOrEmpty())
                query = query.Where(hr => hr.Title == searchModel.Title);

            if (!searchModel.ServiceName.IsNullOrEmpty())
                query = query.Where(hr => hr.HelpService.Title.Contains(searchModel.Title));

            if (searchModel.ServiceId > 0)
                query = query.Where(hr => hr.HelpService.Id == searchModel.ServiceId);

            if (searchModel.CustomerId > 0)
                query = query.Where(hr => hr.CustomerId == searchModel.CustomerId);

            return query.ToList();
        }
    }
}

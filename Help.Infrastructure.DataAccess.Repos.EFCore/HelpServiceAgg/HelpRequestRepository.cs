using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
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

        public async Task Create(CreateHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var helpRequest = new HelpRequest(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.CustomerId, command.ServiceId, command.ProposedPrice);
            _context.HelpRequests.Add(helpRequest);
        }

        public async Task Edit(EditHelpRequestDTO command, CancellationToken cancellationToken)
        {
            var helpRequest = Get(command.Id);
            helpRequest.Edit(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.ServiceId, command.ProposedPrice);
        }

        public async Task<EditHelpRequestDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.HelpRequests.Select(hr =>
            new EditHelpRequestDTO()
            {
                CustomerId = hr.Id,
                Description = hr.Description,
                ExpirationDate = hr.ExpirationDate.ToFarsi(),
                Id = hr.Id,
                Title = hr.Title,
                ProposedPrice = hr.ProposedPrice,
                ServiceId = hr.ServiceId
            }).FirstOrDefault(hr => hr.Id == id);
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

            return query.OrderBy(hr => hr.ExpirationDate).ToList();
        }
    }
}

using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
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

        public void Create(CreateHelpRequestDTO command)
        {
            var helpRequest = new HelpRequest(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.CustomerId, command.ServiceId, command.ProposedPrice);
            _context.HelpRequests.Add(helpRequest);
        }

        public void Edit(EditHelpRequestDTO command)
        {
            var helpRequest = Get(command.Id);
            helpRequest.Edit(command.Title, command.Description, command.ExpirationDate.ToGregorianDateTime(), command.ServiceId, command.ProposedPrice);
        }

        public EditHelpRequestDTO GetDetails(long id)
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
            }).SingleOrDefault(hr => hr.Id == id);
        }

        public List<HelpRequestDTO> Search(SearchHelpRequestDTO searchModel)
        {
            var query = _context.HelpRequests.Select(hr =>
            new HelpRequestDTO()
            {
                Id = hr.Id,
                CustomerId = hr.Id,
                Description = hr.Description,
                Title = hr.Title,
                ExpirationDate = hr.ExpirationDate.ToFarsi(),
                HelpService = new IdTitleHelpServiceDTO()
                    {
                    Id = hr.HelpService.Id,
                    Title = hr.HelpService.Title
                    },
                IsDone = hr.IsDone
            });

            if (!searchModel.Title.IsNullOrEmpty())
                query = query.Where(hr => hr.Title == searchModel.Title);

            if (!searchModel.ServiceName.IsNullOrEmpty())
                query = query.Where(hr => hr.HelpService.Title == searchModel.Title);

            return query.OrderBy(hr => hr.ExpirationDate).ToList();
        }
    }
}

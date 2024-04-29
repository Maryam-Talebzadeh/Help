using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;
using Base_Framework.General;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpServiceRepository : BaseRepository_EFCore<HelpService>, IHelpServiceRepository
    {
        private readonly HelpContext _context;

        public HelpServiceRepository(HelpContext context) :base(context)
        {
            _context = context;
        }

        public void Create(CreateHelpServiceDTO command)
        {
            var helpService = new HelpService(command.Title, command.Description, command.Slug, command.Tags);
            _context.HelpServices.Add(helpService);
        }

        public void Edit(EditHelpServiceDTO command)
        {
            var helpService = Get(command.Id);
            helpService.Edit(command.Title, command.Description, command.Slug, command.Tags);
        }
        public EditHelpServiceDTO GetDetails(long id)
        {
            return _context.HelpServices.Select(s =>
            new EditHelpServiceDTO()
            {
                Id = s.Id,
                Description = s.Description,
                Slug = s.Slug,
                Tags = s.Tags,
                Title = s.Title

            }).SingleOrDefault(s => s.Id == id);
        }

        public List<HelpServiceDTO> Search(SearchHelpServiceDTO searchModel)
        {
            var query = _context.HelpServices.Select(s =>
            new HelpServiceDTO()
            {
                Id = s.Id,
                Title = s.Title,
                CreationDate = s.CreationDate.ToFarsi()
            }) ;

            if (!searchModel.Title.IsNullOrEmpty())
            {
                query = query.Where(s =>
                s.Title == searchModel.Title);
            }

            return query.OrderByDescending(s => s.CreationDate).ToList();
        }
    }
}

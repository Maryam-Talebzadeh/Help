using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;
using Base_Framework.General;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpServiceRepository : BaseRepository_EFCore<HelpService>, IHelpServiceRepository
    {
        private readonly HelpContext _context;

        public HelpServiceRepository(HelpContext context) :base(context)
        {
            _context = context;
        }

        public async Task Create(CreateHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var helpService = new HelpService(command.Title, command.Description, command.Slug, command.Tags);
            _context.HelpServices.Add(helpService);
        }

        public async Task Edit(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var helpService = Get(command.Id);
            helpService.Edit(command.Title, command.Description, command.Slug, command.Tags);
        }

        public async Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return _context.HelpServices.Select(s =>
            new HelpServiceDTO()
            {
                Id = s.Id,
                Title = s.Title,
                Picture = s.Picture.Name,
                CreationDate = s.CreationDate.ToFarsi(),
                Categories = s.Categories.Select(category =>
                     new IdTitleCategoryDTO()
                     {
                         Id = category.Category.Id,
                         Title = category.Category.Title
                     }).ToList()
            }).IgnoreQueryFilters().ToList();
        }

        public async Task<EditHelpServiceDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.HelpServices.Select(s =>
            new EditHelpServiceDTO()
            {
                Id = s.Id,
                Description = s.Description,
                Slug = s.Slug,
                Tags = s.Tags,
                Title = s.Title

            }).FirstOrDefault(s => s.Id == id);
        }

        public async Task<List<HelpServiceDTO>> Search(SearchHelpServiceDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.HelpServices.Select(s =>
            new HelpServiceDTO()
            {
                Id = s.Id,
                Title = s.Title,
                Picture = s.Picture.Name,
                CreationDate = s.CreationDate.ToFarsi(),
                Categories = s.Categories.Select(category =>
                     new IdTitleCategoryDTO()
                     {
                         Id = category.Category.Id,
                         Title = category.Category.Title
                     }).ToList()
            });

            if (!searchModel.Title.IsNullOrEmpty())
            {
                query = query.Where(s =>
                s.Title == searchModel.Title);
            }

            if(!searchModel.Category.IsNullOrEmpty())
            {
                query = query.Where(service => service.Categories.Any(category => category.Title.Contains(searchModel.Category)));
            }

            return query.OrderByDescending(s => s.CreationDate).ToList();
        }
    }
}

using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
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

        public async Task<int> Create(CreateHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var helpService = new HelpService(command.Title, command.Description, command.Slug, command.Tags, command.CategoryId, command.PictureId);
            _context.HelpServices.Add(helpService);
           await Save(cancellationToken);
            return helpService.Id;
        }

        public async Task Edit(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var helpService = Get(command.Id);
            helpService.Edit(command.Title, command.Description, command.Slug, command.Tags);
        }

        public async Task<List<HelpServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _context.HelpServices.Select(s =>
             new HelpServiceDTO()
             {
                 Id = s.Id,
                 Title = s.Title,
                 Picture = s.Picture.Name,
                 PictureId = s.Picture.Id,
                 CreationDate = s.CreationDate.ToFarsi(),
                Category = new IdTitleCategoryDTO()
                {
                    Id = s.CategoryId,
                    Title = s.Category.Title,
                    ParentId = s.Category.ParentId != null  ? s.Category.ParentId  : 0
                }
             }).ToList();
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
                Category = new IdTitleCategoryDTO()
                {
                    Id = s.CategoryId,
                    Title = s.Category.Title
                }
            }).IgnoreQueryFilters().ToList();
        }

        public async Task<HelpServiceDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.HelpServices.Select(s =>
            new HelpServiceDetailDTO()
            {
                Id = s.Id,
                Description = s.Description,
                Slug = s.Slug,
                Tags = s.Tags,
                Title = s.Title,
                CategoryId = s.CategoryId,
                CategoryName = s.Category.Title

            }).FirstOrDefault(s => s.Id == id);
        }

    }
}

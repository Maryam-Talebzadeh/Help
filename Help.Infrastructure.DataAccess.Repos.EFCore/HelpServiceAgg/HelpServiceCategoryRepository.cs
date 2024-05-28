using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpServiceCategoryRepository : BaseRepository_EFCore<Category>, IHelpServiceCategoryRepository
    {
        private readonly HelpContext _context;

        public HelpServiceCategoryRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var category = new Category(command.Title, command.Description, command.ParentId);
            _context.Categories.Add(category);
        }

        public async Task CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var category = new Category(command.Title, command.Description, null);
            _context.Categories.Add(category);
        }

        public async Task Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var category = Get(command.Id);
            category.Edit(command.Title, command.Description);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllParents(CancellationToken cancellationToken)
        {
            return _context.Categories
                .Where(c=> c.ParentId == null && !c.IsRemoved)
                .Select(c =>
          new HelpServiceCategoryDTO()
          {
              Id = c.Id,
              Title = c.Title,
              Description = c.Description,
              CreationDate = c.CreationDate.ToFarsi(),
              Children = c.Children.Select(c =>
                  new IdTitleCategoryDTO()
                  {
                      Id = c.Id,
                      Title = c.Title
                  }).ToList()
          }).ToList();
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return _context.Categories.Select(c =>
            new HelpServiceCategoryDTO()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CreationDate = c.CreationDate.ToFarsi(),
                Children = c.Children.Select(c =>
                    new IdTitleCategoryDTO()
                    {
                        Id = c.Id,
                        Title = c.Title
                    }).ToList(),
                Parent = (c.ParentId != null) ? new IdTitleCategoryDTO
                {
                    Id = c.ParentId,
                    Title = c.Parent.Title
                } : null
            }).IgnoreQueryFilters().ToList();
        }

        public async Task<List<HelpServiceCategoryDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return _context.Categories
                .Where(c => c.ParentId == parentId)
                .Select(c =>
            new HelpServiceCategoryDTO()
            {
                Id = c.Id,
                Description = c.Description,
                Title = c.Title,
                Children = c.Children.Select(c =>
                    new IdTitleCategoryDTO()
                    {
                        Id = c.Id,
                        Title = c.Title
                    }).ToList()
            }).ToList();
        }

        public async Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Categories.Select(c =>
            new HelpServiceCategoryDetailDTO()
            {
                Id = c.Id,
                Description = c.Description,
                ParentId = c.ParentId,
                Title = c.Title,
                Children = c.Children.Select(child =>
                    new IdTitleCategoryDTO()
                    {
                        Id = child.Id,
                        Title = child.Title
                    }).ToList()
            }).FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Categories.Select(c =>
            new HelpServiceCategoryDTO()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Children = c.Children.Select(child =>
                    new IdTitleCategoryDTO()
                    {
                        Id = child.Id,
                        Title = child.Title
                    }).ToList(),
                CreationDate = c.CreationDate.ToFarsi(),
                Parent = (c.ParentId != null) ? new IdTitleCategoryDTO
                {
                    Id = c.ParentId,
                    Title = c.Parent.Title
                } : null
            }).ToList();

        }

        public async Task<List<IdTitleCategoryDTO>> GetAllIdTitleDTO( CancellationToken cancellationToken)
        {
            return _context.Categories.Select(c =>
            new IdTitleCategoryDTO()
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }
    }
}

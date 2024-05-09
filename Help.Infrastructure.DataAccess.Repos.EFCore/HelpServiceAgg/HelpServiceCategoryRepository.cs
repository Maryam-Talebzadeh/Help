using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
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

        public HelpServiceCategoryRepository(HelpContext context) :base(context)
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
            var category = new Category(command.Title, command.Description, 0);
            _context.Categories.Add(category);
        }

        public async Task Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var category = Get(command.Id);
            category.Edit(command.Title, command.Description);
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
                    }).ToList()
            }).IgnoreQueryFilters().ToList();
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
                Children = c.Children.Select(c =>
                    new IdTitleCategoryDTO()
                    {
                        Id = c.Id,
                        Title = c.Title
                    } ).ToList()
            }).FirstOrDefault(c => c.Id == id);
        }

            public async Task<List<HelpServiceCategoryDTO>> Search(SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Categories.Select(c =>
            new HelpServiceCategoryDTO()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CreationDate = c.CreationDate.ToFarsi(),
                Children =c.Children.Select(c =>
                    new IdTitleCategoryDTO()
                    {
                        Id = c.Id,
                        Title = c.Title
                    }).ToList()
            });

            if(!searchModel.Title.IsNullOrEmpty())
            {
                query = query.Where(category => category.Title.Contains(searchModel.Title));
            }

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}

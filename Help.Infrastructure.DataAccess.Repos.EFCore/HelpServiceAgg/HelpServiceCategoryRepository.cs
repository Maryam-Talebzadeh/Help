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

        public void CreateChild(CreateChildHelpServiceCategoryDTO command)
        {
            var category = new Category(command.Title, command.Description, command.ParentId);
            _context.Categories.Add(category);
        }

        public void CreateParent(CreateParentHelpServiceCategoryDTO command)
        {
            var category = new Category(command.Title, command.Description, 0);
            _context.Categories.Add(category);
        }

        public void Edit(EditHelpServiceCategoryDTO command)
        {
            var category = Get(command.Id);
            category.Edit(command.Title, command.Description);
        }

        public List<HelpServiceCategoryDTO> GetAllRemoved()
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

        public HelpServiceCategoryDetailDTO GetDetails(int id)
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
            }).SingleOrDefault(c => c.Id == id);
        }

            public List<HelpServiceCategoryDTO> Search(SearchHelpServiceCategoryDTO searchModel)
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

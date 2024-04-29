using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;


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

        public HelpServiceCategoryDetailDTO GetDetails(long id)
        {
            return _context.Categories.Select(c =>
            new HelpServiceCategoryDetailDTO()
            {
                Id = c.Id,
                Description = c.Description,
                ParentId = c.ParentId,
                Title = c.Title,
                Children = c.Children.Select(c =>
                    new HelpServiceCategoryDTO()
            {
                   Id = c.Id,
                   Title = c.Title,
                   Description = c.Description,
                   CreationDate = c.CreationDate.ToFarsi(),
                   Children = c.Children.Select(child =>
                        new HelpServiceCategoryDTO
                            {
                            Id = child.Id,
                            Title = child.Title,
                            Description = child.Description
                            }).ToList(),
                   HelpServices = c.Services.Select(service =>
                         new HelpServiceDTO()
                            {
                             Id = service.ServiceId,
                             Title = service.HelpService.Title,
                             CreationDate = service.HelpService.CreationDate.ToFarsi(),
                             Picture = service.HelpService.Picture.Name
                            }).ToList()

            }).ToList()

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
                Children = c.Children.Select(child =>
                new HelpServiceCategoryDTO
                {
                    Id = child.Id,
                    Title = child.Title,
                    Description = child.Description
                }).ToList(),
                HelpServices = c.Services.Select(service=>
                new HelpServiceDTO()
                {
                    Id = service.ServiceId,
                    Title = service.HelpService.Title,
                    CreationDate = service.HelpService.CreationDate.ToFarsi(),
                    Picture = service.HelpService.Picture.Name
                }).ToList()
            });

            if(!searchModel.Title.IsNullOrEmpty())
            {
                query = query.Where(category => category.Title == searchModel.Title);
            }

            return query.OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}

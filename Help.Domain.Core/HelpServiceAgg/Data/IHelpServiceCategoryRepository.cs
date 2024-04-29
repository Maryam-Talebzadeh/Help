using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServiceCategoryRepository : IRepository<Category>
    {
        void Create(CreateHelpServiceCategoryDTO command);
        void Edit(EditHelpServiceCategoryDTO command);
        EditHelpServiceCategoryDTO GetDetails(long id);
        List<HelpServiceCategoryDTO> Search(SearchHelpServiceCategoryDTO searchModel);
    }
}

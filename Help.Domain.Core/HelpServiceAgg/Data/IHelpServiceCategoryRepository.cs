using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServiceCategoryRepository : IRepository<Category>
    {
        void CreateChild(CreateChildHelpServiceCategoryDTO command);
        void CreateParent(CreateParentHelpServiceCategoryDTO command);
        void Edit(EditHelpServiceCategoryDTO command);
        HelpServiceCategoryDetailDTO GetDetails(int id);
        List<HelpServiceCategoryDTO> Search(SearchHelpServiceCategoryDTO searchModel);
        List<HelpServiceCategoryDTO> GetAllRemoved();
    }
}

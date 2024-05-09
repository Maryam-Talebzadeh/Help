using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface IHelpServiceCategoryRepository : IRepository<Category>
    {
        Task CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> Search(SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken);
    }
}

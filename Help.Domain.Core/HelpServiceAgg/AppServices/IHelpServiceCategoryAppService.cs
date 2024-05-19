using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;

namespace Help.Domain.Core.HelpServiceAgg.AppServices
{
    public interface IHelpServiceCategoryAppService
    {
        Task<OperationResult> CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> Search(SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAllParents(CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(int id, CancellationToken cancellationToken);
        Task<List<IdTitleCategoryDTO>> GetAllIdTitleDTO(CancellationToken cancellationToken);
    }
}

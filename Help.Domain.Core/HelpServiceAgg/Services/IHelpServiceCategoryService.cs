using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;

namespace Help.Domain.Core.HelpServiceAgg.Services
{
    public interface IHelpServiceCategoryService
    {
        Task<OperationResult> CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken);
        Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> Search(List<HelpServiceCategoryDTO> searchList, SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAllParents(CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<List<HelpServiceCategoryDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken);
        Task<OperationResult> Remove(int id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(int id, CancellationToken cancellationToken);
    }
}

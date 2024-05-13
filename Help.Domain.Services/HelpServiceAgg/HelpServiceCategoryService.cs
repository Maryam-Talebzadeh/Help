using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpServiceCategoryService : IHelpServiceCategoryService
    {
        private readonly IHelpServiceCategoryRepository _helpServiceCategoryRepository;
        private readonly Type _type = new HelpServiceCategoryDTO().GetType();

        public HelpServiceCategoryService(IHelpServiceCategoryRepository helpServiceCategoryRepository)
        {
            _helpServiceCategoryRepository = helpServiceCategoryRepository;
        }

        public async Task<OperationResult> CreateChild(CreateChildHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _helpServiceCategoryRepository.CreateChild(command, cancellationToken);
                await _helpServiceCategoryRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> CreateParent(CreateParentHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _helpServiceCategoryRepository.CreateParent(command, cancellationToken);
                await _helpServiceCategoryRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditHelpServiceCategoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _helpServiceCategoryRepository.IsExist(s => s.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServiceCategoryRepository.Edit(command, cancellationToken);
            await _helpServiceCategoryRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _helpServiceCategoryRepository.GetAll(cancellationToken);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllParents(CancellationToken cancellationToken)
        {
            return await _helpServiceCategoryRepository.GetAllParents(cancellationToken);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return await _helpServiceCategoryRepository.GetAllRemoved(cancellationToken);
        }

        public async Task<List<HelpServiceCategoryDTO>> GetChildsByParentId(int parentId, CancellationToken cancellationToken)
        {
            return await _helpServiceCategoryRepository.GetChildsByParentId(parentId, cancellationToken);
        }

        public async Task<HelpServiceCategoryDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpServiceCategoryRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _helpServiceCategoryRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServiceCategoryRepository.Remove(id, cancellationToken);
            await _helpServiceCategoryRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Restore(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _helpServiceCategoryRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServiceCategoryRepository.Restore(id, cancellationToken);
            await _helpServiceCategoryRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpServiceCategoryDTO>> Search(List<HelpServiceCategoryDTO> searchList, SearchHelpServiceCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            if (searchModel.Title != null)
            {
                searchList = searchList.Where(s =>
                s.Title == searchModel.Title).ToList();
            }

            return searchList.OrderBy(c => c.Title).ToList();
        }
    }
}

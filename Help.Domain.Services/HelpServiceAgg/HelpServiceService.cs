using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpServiceService : IHelpServiceService
    {
        private readonly IHelpServiceRepository _helpServiceRepository;
        private readonly Type _type = new HelpServiceDTO().GetType();

        public HelpServiceService(IHelpServiceRepository helpServiceRepository)
        {
            _helpServiceRepository = helpServiceRepository;
        }

        public async Task<OperationResult> Create(CreateHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _helpServiceRepository.Create(command, cancellationToken);
                await _helpServiceRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditHelpServiceDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _helpServiceRepository.IsExist(s => s.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServiceRepository.Edit(command, cancellationToken);
            await _helpServiceRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
           return  await _helpServiceRepository.GetAll(cancellationToken);
        }

        public async Task<List<HelpServiceDTO>> GetAllRemoved(CancellationToken cancellationToken)
        {
            return await _helpServiceRepository.GetAllRemoved(cancellationToken);
        }

        public async Task<EditHelpServiceDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpServiceRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _helpServiceRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServiceRepository.Remove(id, cancellationToken);
            await _helpServiceRepository.Save(cancellationToken);

            return operation.Succedded();
        }

       public async Task<List<HelpServiceDTO>> Search(List<HelpServiceDTO> searchList, SearchHelpServiceDTO searchModel, CancellationToken cancellationToken)
        {
           if(searchModel.Title != null)
            {
                searchList = searchList.Where(s =>
                s.Title == searchModel.Title).ToList();
            }

            if (searchModel.Category != null)
            {
                searchList = searchList.Where(service => service.Categories.Any(category => category.Title.Contains(searchModel.Category))).ToList();
            }

            return searchList;
        }
    }
}

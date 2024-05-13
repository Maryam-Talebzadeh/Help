using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestStatus;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpRequestStatusService : IHelpRequestStatusService
    {
        private readonly Type _type = new HelpRequestDTO().GetType();
        private readonly IHelpRequestStatusRepository _helpRequestStatusRepository;

        public HelpRequestStatusService(IHelpRequestStatusRepository helpRequestStatusRepository)
        {
            _helpRequestStatusRepository = helpRequestStatusRepository;
        }
        public async Task<OperationResult> Create(CreateHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                await _helpRequestStatusRepository.Create(command, cancellationToken);
                await _helpRequestStatusRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _helpRequestStatusRepository.IsExist(s => s.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestStatusRepository.Edit(command, cancellationToken);
            await _helpRequestStatusRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestStatusDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _helpRequestStatusRepository.GetAll(cancellationToken);
        }

        public async Task<EditHelpRequestStatusDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpRequestStatusRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _helpRequestStatusRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestStatusRepository.Remove(id, cancellationToken);
            await _helpRequestStatusRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Restore(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (await _helpRequestStatusRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestStatusRepository.Restore(id, cancellationToken);
            await _helpRequestStatusRepository.Save(cancellationToken);

            return operation.Succedded();
        }
    }
}

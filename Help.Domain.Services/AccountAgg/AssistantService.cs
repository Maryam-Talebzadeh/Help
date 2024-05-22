using Base_Framework.Domain.Services;
using Base_Framework.General.Hashing;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Assistant;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class AssistantService : IAssistantService
    {
        private readonly IAssistantRepository _assistantRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly Type _type = new AssistantDTO().GetType();

        public AssistantService(IAssistantRepository assistantRepository, IPasswordHasher passwordHasher)
        {
            _assistantRepository = assistantRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> ChangePassword(ChangeAssistantPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, changePasswordModel.Id);

            if (!await  _assistantRepository.IsExist(x => x.Id == changePasswordModel.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (changePasswordModel.Password != changePasswordModel.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            changePasswordModel.Password = _passwordHasher.Hash(changePasswordModel.Password);
            await  _assistantRepository.ChangePassword(changePasswordModel, cancellationToken);
            await  _assistantRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Create(CreateAssistantDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);
            command.RoleId = 3;

            if (await  _assistantRepository.IsExist(c => c.UserName == command.UserName, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await  _assistantRepository.IsExist(c => c.Mobile == command.Mobile, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            command.Password = _passwordHasher.Hash(command.Password);
            int customerId = await  _assistantRepository.Create(command, cancellationToken);
            operation.RecordReferenceId = customerId;

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditAssistantDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await  _assistantRepository.IsExist(c => c.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (await  _assistantRepository.IsExist(c => c.UserName == command.UserName && c.Id != command.Id, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await  _assistantRepository.IsExist(c => c.Mobile == command.Mobile && c.Id != command.Id, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            await  _assistantRepository.Edit(command, cancellationToken);
            await  _assistantRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditAssistantDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await  _assistantRepository.GetDetails(id, cancellationToken);
        }

        public async Task<List<AssistantDTO>> Search(SearchAssistantDTO searchModel, CancellationToken cancellationToken)
        {
            return await  _assistantRepository.Search(searchModel, cancellationToken);
        }
    }
}

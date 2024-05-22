using Base_Framework.Domain.Services;
using Base_Framework.General.Hashing;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Admin;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _AdminRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly Type _type = new AdminDTO().GetType();

        public AdminService(IAdminRepository AdminRepository, IPasswordHasher passwordHasher)
        {
            _AdminRepository = AdminRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> ChangePassword(ChangeAdminPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, changePasswordModel.Id);

            if (!await  _AdminRepository.IsExist(x => x.Id == changePasswordModel.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (changePasswordModel.Password != changePasswordModel.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            changePasswordModel.Password = _passwordHasher.Hash(changePasswordModel.Password);
            await  _AdminRepository.ChangePassword(changePasswordModel, cancellationToken);
            await  _AdminRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Create(CreateAdminDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            if (await _AdminRepository.IsExist(c => c.UserName == command.UserName, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await  _AdminRepository.IsExist(c => c.Mobile == command.Mobile, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            command.Password = _passwordHasher.Hash(command.Password);
            int customerId = await  _AdminRepository.Create(command, cancellationToken);
            operation.RecordReferenceId = customerId;

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditAdminDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await  _AdminRepository.IsExist(c => c.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (await  _AdminRepository.IsExist(c => c.UserName == command.UserName && c.Id != command.Id, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await  _AdminRepository.IsExist(c => c.Mobile == command.Mobile && c.Id != command.Id, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            await  _AdminRepository.Edit(command, cancellationToken);
            await  _AdminRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditAdminDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await  _AdminRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _AdminRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _AdminRepository.Remove(id, cancellationToken);
            await _AdminRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<AdminDTO>> Search(SearchAdminDTO searchModel, CancellationToken cancellationToken)
        {
            return await  _AdminRepository.Search(searchModel, cancellationToken);
        }
    }
}

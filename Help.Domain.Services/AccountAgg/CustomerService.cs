using Base_Framework.Domain.Services;
using Base_Framework.General.Hashing;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly Type _type = new CustomerDTO().GetType();

        public CustomerService(ICustomerRepository customerRepository, IPasswordHasher passwordHasher)
        {
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Active(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerRepository.Active(id, cancellationToken);
            await _customerRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> ChangePassword(ChangeCustomerPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, changePasswordModel.Id);

            if (!await _customerRepository.IsExist(x => x.Id == changePasswordModel.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (changePasswordModel.Password != changePasswordModel.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            changePasswordModel.Password = _passwordHasher.Hash(changePasswordModel.Password);
            await _customerRepository.Active(changePasswordModel.Id, cancellationToken);
            await _customerRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Create(CreateCustomerDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            if (await _customerRepository.IsExist(c => c.UserName == command.UserName, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await _customerRepository.IsExist(c => c.Mobile == command.Mobile, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            command.Password = _passwordHasher.Hash(command.Password);
           int customerId = await _customerRepository.Create(command, cancellationToken);
            operation.RecordReferenceId = customerId;

            return operation.Succedded();

        }

        public async Task<OperationResult> DeActive(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerRepository.DeActive(id, cancellationToken);
            await _customerRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditCustomerDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);

            if (await _customerRepository.IsExist(c => c.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (await _customerRepository.IsExist(c => c.UserName == command.UserName && c.Id != command.Id, cancellationToken))
                operation.Failed("نام کاربری تکراری می باشد. لطفا نام کاربری دیگری برای خود انتخاب کنید.");

            if (await _customerRepository.IsExist(c => c.Mobile == command.Mobile && c.Id != command.Id, cancellationToken))
                operation.Failed("شماره موبایل تکراری می باشد. لطفا شماره موبایل دیگری وارد کنید.");

            await _customerRepository.Edit(command, cancellationToken);
            await _customerRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerRepository.Remove(id, cancellationToken);
            await _customerRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerRepository.Search(searchModel, cancellationToken);
        }
    }
}

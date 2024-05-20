using Base_Framework.Domain.Services;
using Base_Framework.General;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Services;

namespace Help.Domain.Services.AccountAgg
{
    public class CustomerPictureService : ICustomerPictureService
    {
        private readonly ICustomerPictureRepository _customerPictureRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly Type _type = new CustomerPictureDTO().GetType();

        public CustomerPictureService(ICustomerPictureRepository customerPictureRepository, ICustomerRepository customerRepository)
        {
            _customerPictureRepository = customerPictureRepository;
            _customerRepository = customerRepository;
        }

        public async Task<OperationResult> Confirm(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerPictureRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerPictureRepository.Confirm(id, cancellationToken);
            await _customerPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> CreateDefault(CreateCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);
            command.Alt = "دیفالت پروفایل";
            command.Title = "دیفالت پروفایل";
            command.Name = "DefaultProfile.jpg";

            try
            {
                #region Save picture

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "ProfilePictures", command.Name);
                FileHandler.SaveImage(path, command.Picture);

                #endregion

                await _customerPictureRepository.Create(command, cancellationToken);
                await _customerPictureRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var customerUserName = await _customerRepository.GetUserNameById(command.CustomerID, cancellationToken);
            command.Alt = "پروفایل" + customerUserName;
            command.Title = "پروفایل" + customerUserName;

            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "ProfilePictures");

                #region Delete Old Image

                FileHandler.DeleteFile(Path.Combine(path, command.Name));

                #endregion

                #region Save picture

                command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                path = Path.Combine(path, command.Name);
                FileHandler.SaveImage(path, command.Picture);

                #endregion

            }

            var operation = new OperationResult(_type, command.Id);

            if (!await _customerPictureRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerPictureRepository.Edit(command, cancellationToken);
            await _customerPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<CustomerPictureDTO> GetByCustomerId(int customerId, CancellationToken cancellationToken)
        {
           return await _customerPictureRepository.GetByCustomerId(customerId, cancellationToken);
        }

        public async Task<EditCustomerPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _customerPictureRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerPictureRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerPictureRepository.Reject(id, cancellationToken);
            await _customerPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _customerPictureRepository.IsExist(s => s.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _customerPictureRepository.Remove(id, cancellationToken);
            await _customerPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<CustomerPictureDTO>> SearchUnConfirmed(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerPictureRepository.SearchUnConfirmed(searchModel, cancellationToken);
        }

        public async Task<List<CustomerPictureDTO>> Serach(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerPictureRepository.Serach(searchModel, cancellationToken);
        }
    }
}

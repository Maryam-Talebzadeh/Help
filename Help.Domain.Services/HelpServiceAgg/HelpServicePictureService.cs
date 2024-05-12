using Base_Framework.Domain.Services;
using Base_Framework.General;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpServicePictureService : IHelpServicePictureService
    {
        private readonly IHelpServicePictureRepository _helpServicePictureRepository;
        private readonly Type _type = new HelpServicePictureDTO().GetType();

        public HelpServicePictureService(IHelpServicePictureRepository helpServicePictureRepository)
        {
            _helpServicePictureRepository = helpServicePictureRepository;
        }

        public async Task<OperationResult> Create(CreateHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            #region Save picture

            command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "HelpServicePictures", command.Name);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            await _helpServicePictureRepository.Create(command, cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "HelpRequestPictures");

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

            if (!await _helpServicePictureRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServicePictureRepository.Edit(command, cancellationToken);
            await _helpServicePictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpServicePictureRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _helpServicePictureRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpServicePictureRepository.Remove(id, cancellationToken);
            await _helpServicePictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }
    }
}

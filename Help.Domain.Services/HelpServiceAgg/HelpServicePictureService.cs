using Base_Framework.Domain.Services;
using Base_Framework.General;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpServicePictureService : IHelpServicePictureService
    {
        private readonly IHelpServicePictureRepository _HelpServicePictureRepository;
        private readonly Type _type = new HelpServicePictureDTO().GetType();

        public HelpServicePictureService(IHelpServicePictureRepository HelpServicePictureRepository)
        {
            _HelpServicePictureRepository = HelpServicePictureRepository;
        }



        public async Task<OperationResult> CreateDefault(CreateHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);
            command.Alt = "دیفالت ";
            command.Title = "دیفالت ";
            command.Name = "DefaultHelpServicePicture.jpg";

            try
            {
               int id = await _HelpServicePictureRepository.Create(command, cancellationToken);
                await _HelpServicePictureRepository.Save(cancellationToken);
                operation.RecordReferenceId = id;
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, command.Id);


            if (!await _HelpServicePictureRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);


            command.Alt = "عکس دیفالت سرویس" ;
            command.Title = "عکس دیفالت سرویس";

            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "HelpServicePictures");

                if (command.Name != "DefaultHelpServicePicture.jpg")
                {

                    #region Delete Old Image


                    FileHandler.DeleteFile(Path.Combine(path, command.Name));

                    #endregion

                }

                #region Save picture

                command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                path = Path.Combine(path, command.Name);
                FileHandler.SaveImage(path, command.Picture);

                #endregion

            }

            await _HelpServicePictureRepository.Edit(command, cancellationToken);
            await _HelpServicePictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _HelpServicePictureRepository.GetDetails(id, cancellationToken);
        }


        public async Task<OperationResult> EditDefaultPicture(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            try
            {
                if (command.Picture != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "HelpServicePictures");

                    if(command.Name != "DefaultHelpServicePicture.jpg")
                    {
                        #region Delete Old Image

                        FileHandler.DeleteFile(Path.Combine(path, command.Name));

                        #endregion
                    }



                    #region Save picture

                    command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                    path = Path.Combine(path, command.Name);
                    FileHandler.SaveImage(path, command.Picture);

                    #endregion

                }

               await _HelpServicePictureRepository.Edit(command, cancellationToken);
                await _HelpServicePictureRepository.Save(cancellationToken);
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }


        }

        public async Task<HelpServicePictureDTO> GetByHelpServiceId(int HelpServiceId, CancellationToken cancellationToken)
        {
            return await _HelpServicePictureRepository.GetByHelpServiceId(HelpServiceId, cancellationToken);
        }

    }
}

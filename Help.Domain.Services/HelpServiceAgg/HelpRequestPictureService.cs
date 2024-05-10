﻿using Base_Framework.Domain.Services;
using Base_Framework.General;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.Services.HelpServiceAgg
{
    public class HelpRequestPictureService : IHelpRequestPictureService
    {
        private readonly IHelpRequestPictureRepository _helpRequestPictureRepository;
        private readonly Type _type = new HelpRequestPictureDTO().GetType();

        public HelpRequestPictureService(IHelpRequestPictureRepository helpRequestPictureRepository)
        {
            _helpRequestPictureRepository = helpRequestPictureRepository;
        }

        public async Task<OperationResult> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, 0);

            #region Save picture

            command.Name = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "HelpRequestPictures", command.Name);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            await _helpRequestPictureRepository.Create(command, cancellationToken);

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken)
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

            if (!await _helpRequestPictureRepository.IsExist(x => x.Id == command.Id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestPictureRepository.Edit(command, cancellationToken);
            await _helpRequestPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }

        public async Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken)
        {
            return await _helpRequestPictureRepository.GetAll(helpRequestId, cancellationToken);
        }

        public async Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(int helpRequestId, CancellationToken cancellationToken)
        {
            return await _helpRequestPictureRepository.GetAllUnConfirmed(helpRequestId, cancellationToken);
        }

        public async Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(CancellationToken cancellationToken)
        {
            return await _helpRequestPictureRepository.GetAllUnConfirmed(cancellationToken);
        }

        public async Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _helpRequestPictureRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(int id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult(_type, id);

            if (!await _helpRequestPictureRepository.IsExist(x => x.Id == id, cancellationToken))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _helpRequestPictureRepository.Remove(id, cancellationToken);
            await _helpRequestPictureRepository.Save(cancellationToken);

            return operation.Succedded();
        }
    }
}

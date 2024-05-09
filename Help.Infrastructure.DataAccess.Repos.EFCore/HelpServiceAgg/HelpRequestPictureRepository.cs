using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpRequestPictureRepository : BaseRepository_EFCore<HelpRequestPicture>, IHelpRequestPictureRepository
    {
        private readonly HelpContext _context;

        public HelpRequestPictureRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> Create(CreateHelpRequestPictureDTO command, CancellationToken cancellationToken)
        {
            var picture = new HelpRequestPicture(command.Name, command.Title, command.Alt, command.HelpRequestId);
            _context.HelpRequestPictures.Add(picture);
            await Save(cancellationToken);
            return picture.Id;
        }

        public async Task Edit(EditHelpRequestPictureDTO command, CancellationToken cancellationToken)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }

        public async Task<List<HelpRequestPictureDTO>> GetAll(int helpRequestId, CancellationToken cancellationToken)
        {
            return _context.HelpRequestPictures
                .Where(p => p.HelpRequestId == helpRequestId && p.IsConfirmed)
                .Select(p =>
                new HelpRequestPictureDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Name = p.Name,
                    Alt = p.Alt,
                    HelpRequestId = p.HelpRequestId
                }).ToList();
        }

        public async Task<List<HelpRequestPictureDTO>> GetAllUnConfirmed(int helpRequestId, CancellationToken cancellationToken)
        {
            return _context.HelpRequestPictures
               .Where(p => p.HelpRequestId == helpRequestId && !p.IsConfirmed)
               .Select(p =>
               new HelpRequestPictureDTO
               {
                   Id = p.Id,
                   Title = p.Title,
                   Name = p.Name,
                   Alt = p.Alt,
                   HelpRequestId = p.HelpRequestId
               }).ToList();
        }

        public async Task<EditHelpRequestPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.HelpRequestPictures.Select(p =>
                new EditHelpRequestPictureDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Name = p.Name,
                    Alt = p.Alt,
                    HelpRequestId = p.HelpRequestId
                }).FirstOrDefault(p => p.Id == id);
        }
    }
    
}

using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpServicePictureRepository : BaseRepository_EFCore<HelpServicePicture>, IHelpServicePictureRepository
    {
        private readonly HelpContext _context;

        public HelpServicePictureRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> Create(CreateHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var picture = new HelpServicePicture(command.Name, command.Title, command.Alt);
            _context.HelpServicePictures.Add(picture);
            await Save(cancellationToken);
            return picture.Id;
        }

        public async Task Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }

        public async Task<HelpServicePictureDTO> GetByHelpServiceId(int HelpServiceId, CancellationToken cancellationToken)
        {
            return await _context.HelpServicePictures.Select(p =>
            new HelpServicePictureDTO
            {
                Id = p.Id,
                Alt = p.Alt,
                Name = p.Name,
                Title = p.Title
            }).FirstOrDefaultAsync(p => p.HelpServiceId == HelpServiceId);
        }

        public async Task<EditHelpServicePictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _context.HelpServicePictures.Select(p =>
            new EditHelpServicePictureDTO
            {
                Id = p.Id,
                Alt = p.Alt,
                Name = p.Name,
                Title = p.Title
            }).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

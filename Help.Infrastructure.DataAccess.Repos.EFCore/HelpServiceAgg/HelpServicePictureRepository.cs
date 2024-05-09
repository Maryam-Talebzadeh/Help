using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

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
            var picture = new HelpServicePicture(command.Name, command.Title, command.Alt, command.HelpServiceId);
            _context.HelpServicePictures.Add(picture);
            await Save(cancellationToken);
            return picture.Id;
        }

        public async Task Edit(EditHelpServicePictureDTO command, CancellationToken cancellationToken)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }
    }
}

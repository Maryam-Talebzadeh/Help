using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestPicture;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

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
    }
    
}

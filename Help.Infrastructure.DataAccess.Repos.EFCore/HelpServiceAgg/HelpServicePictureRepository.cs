using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServicePicture;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpServicePictureRepository : BaseRepository_EFCore<ServicePicture>, IHelpServicePictureRepository
    {
        private readonly HelpContext _context;

        public HelpServicePictureRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateHelpServicePictureDTO command)
        {
            var picture = new ServicePicture(command.Name, command.Title, command.Alt, command.HelpServiceId);
            _context.ServicePictures.Add(picture);
        }

        public void Edit(EditHelpServicePictureDTO command)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }
    }
}

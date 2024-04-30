using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class CustomerPictureRepository : BaseRepository_EFCore<CustomerPicture>, ICustomerPictureRepository
    {
        private readonly HelpContext _context;

        public CustomerPictureRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateCustomerPictureDTO command)
        {
            var picture = new CustomerPicture(command.Name, command.Title, command.Alt);
            _context.CustomerPictures.Add(picture);
        }

        public void Edit(EditCustomerPictureDTO command)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }
    }
}

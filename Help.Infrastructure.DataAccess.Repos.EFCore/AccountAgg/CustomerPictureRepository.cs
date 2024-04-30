using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System.Net;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class CustomerPictureRepository : BaseRepository_EFCore<CustomerPicture>, ICustomerPictureRepository
    {
        private readonly HelpContext _context;

        public CustomerPictureRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public int Create(CreateCustomerPictureDTO command)
        {
            var picture = new CustomerPicture(command.Name, command.Title, command.Alt);
            _context.CustomerPictures.Add(picture);
            Save();
            return picture.Id;
        }

        public void Edit(EditCustomerPictureDTO command)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }
    }
}

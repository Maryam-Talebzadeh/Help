using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Address;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AddressRepository : BaseRepository_EFCore<Address>, IAddressRepository
    {
        private readonly HelpContext _context;

        public AddressRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public int Create(CreateAddressDTO command)
        {
            var address = new Address(command.Description, command.CityId, command.StreetName, command.AlleyNumber);
            _context.Addresses.Add(address);
            Save();
            return address.Id;
        }

        public void Edit(EditAddressDTO command)
        {
            var address = Get(command.Id);
            address.Edit(command.Description, command.CityId, command.StreetName, command.AlleyNumber);
        }
    }
}

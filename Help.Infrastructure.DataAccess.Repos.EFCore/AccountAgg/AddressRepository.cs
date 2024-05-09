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

        public async Task<int> Create(CreateAddressDTO command, CancellationToken cancellationToken)
        {
            var address = new Address(command.Description, command.CityId, command.StreetName, command.AlleyNumber);
            _context.Addresses.Add(address);
            await Save(cancellationToken);
            return address.Id;
        }

        public async Task Edit(EditAddressDTO command, CancellationToken cancellationToken)
        {
            var address = Get(command.Id);
            address.Edit(command.Description, command.CityId, command.StreetName, command.AlleyNumber);
        }
    }
}

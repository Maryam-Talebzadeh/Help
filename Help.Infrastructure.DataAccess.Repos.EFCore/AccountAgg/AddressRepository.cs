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
            _context.SaveChanges();
            return address.Id;
        }

        public async Task Edit(EditAddressDTO command, CancellationToken cancellationToken)
        {
            var address = Get(command.Id);
            address.Edit(command.Description, command.CityId, command.StreetName, command.AlleyNumber);
        }

        public async Task<EditAddressDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Addresses.Select(a =>
            new EditAddressDTO
            {
                Id = a.Id,
                AlleyNumber = a.AlleyNumber,
                StreetName = a.StreetName,
                CityId = a.CityId,
                Description = a.Description,
                CustomerId = a.Customer.Id
            }).FirstOrDefault(s => s.Id == id);
        }
    }
}

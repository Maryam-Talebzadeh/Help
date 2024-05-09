using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Customer;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.General;
using Microsoft.IdentityModel.Tokens;
using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class CustomerRepository : BaseRepository_EFCore<Customer>, ICustomerRepository
    {
        private readonly HelpContext _context;

        public CustomerRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            var customer = Get(id);
            customer.Activate();
        }

        public async Task Create(CreateCustomerDTO command, CancellationToken cancellationToken)
        {
            var customer = new Customer(command.FullName, command.UserName, command.Password, command.Email, command.CardNumber, command.PhoneNumber,command.Bio, command.PictureId, command.Birthday.ToGregorianDateTime(), command.AddressId);
            _context.Customers.Add(customer);
        }

        public async Task Edit(EditCustomerDTO command, CancellationToken cancellationToken)
        {
            var customer = Get(command.Id);
            customer.Edit(command.FullName, command.UserName,command.Email, command.CardNumber, command.PhoneNumber, command.Bio, command.Birthday.ToGregorianDateTime());
        }

        public async Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Customers.Select(c =>
            new CustomerDetailDTO()
            {
                Id = c.Id,
                Bio = c.Bio,
                Email = c.Email,
                FullName = c.FullName,
                Birthday = c.Birthday.ToFarsi(),
                UserName = c.UserName,
                AddressId = c.AddressId,
                Password = c.Password,
                CardNumber = c.CardNumber,
                PhoneNumber = c.PhoneNumber,
                PictureId = c.PictureId,
                Profile = new CustomerPictureDTO()
                {
                    Title = c.Profile.Title,
                    Name = c.Profile.Name,
                    Alt = c.Profile.Alt,
                    CustomerId = c.Id
                }
            }).FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<CustomerDTO>> Search(SearchCustomerDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Customers.Select(c =>
            new CustomerDTO()
            {
                Id = c.Id,
               Picture = new CustomerPictureDTO()
                   {
                   Title = c.Profile.Title,
                   Name = c.Profile.Name,
                   Alt = c.Profile.Alt,
                   CustomerId = c.Id
                   },
                FullName = c.FullName,
               
            });

            if (!searchModel.Information.IsNullOrEmpty())
                query = query.Where(c => c.FullName.Contains(searchModel.Information) || c.UserName.Contains(searchModel.Information) || c.Email.Contains(searchModel.Information));

            return query.OrderBy(c => c.UserName).ToList();
        }
    }
}

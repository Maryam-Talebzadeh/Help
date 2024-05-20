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

        public async Task ChangePassword(ChangeCustomerPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var customer = Get(changePasswordModel.Id);
            customer.ChangePassword(changePasswordModel.Password);
        }

        public async Task<int> Create(CreateCustomerDTO command, CancellationToken cancellationToken)
        {
            var customer = new Customer(command.FullName, command.UserName, command.Password, command.Email, command.Mobile, command.RoleId, command.CardNumber,command.Bio, command.Birthday.ToGregorianDateTime(), command.AddressId);
            _context.Customers.Add(customer);
           await Save(cancellationToken);
            return customer.Id;
        }

        public async Task DeActive(int id, CancellationToken cancellationToken)
        {
            var customer = Get(id);
            customer.DeActive();
        }

        public async Task Edit(EditCustomerDTO command, CancellationToken cancellationToken)
        {
            var customer = Get(command.Id);
            customer.Edit(command.FullName, command.UserName,command.Email, command.CardNumber, command.Bio, command.Birthday.ToGregorianDateTime(), command.Mobile, command.RoleId);
        }

        public async Task<CustomerDetailDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Customers.Select(c =>
            new CustomerDetailDTO()
            {
                Id = c.Id,
                Bio = c.Bio,
                Email = c.Email,
                Mobile = c.Mobile,
                RoleId = c.RoleId,
                FullName = c.FullName,
                Birthday = c.Birthday.ToFarsi(),
                UserName = c.UserName,
                AddressId = c.AddressId,
                CardNumber = c.CardNumber,
                Profile = new CustomerPictureDTO()
                {
                    Title = c.Profile.Title,
                    Name = c.Profile.Name,
                    Alt = c.Profile.Alt,
                    CustomerId = c.Id
                }
            }).FirstOrDefault(c => c.Id == id);
        }

        public async Task<string> GetUserNameById(int id, CancellationToken cancellationToken)
        {
            return _context.Customers.Where( c => c.Id == id).Select(c => c.UserName).FirstOrDefault();
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
                RoleId = c.RoleId,
                UserName = c.UserName,
                Email = c.Email,
                Mobile = c.Mobile,
                IsActive = c.IsActive,
                CreationDate = c.CreationDate.ToFarsi()
            });;

            if (!searchModel.FullName.IsNullOrEmpty())
                query = query.Where(c => c.FullName.Contains(searchModel.FullName));

            if (!searchModel.UserName.IsNullOrEmpty())
                query = query.Where(c => c.UserName.Contains(searchModel.UserName));

            if (!searchModel.Mobile.IsNullOrEmpty())
                query = query.Where(c => c.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(c => c.RoleId == searchModel.RoleId);

            return query.OrderBy(c => c.UserName).ToList();
        }
    }
}

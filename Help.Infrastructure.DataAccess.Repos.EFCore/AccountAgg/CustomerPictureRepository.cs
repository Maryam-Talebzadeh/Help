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

        public async Task Confirm(int id, CancellationToken cancellationToken)
        {
            var picture = Get(id);
            picture.Confirm();
        }

        public async Task<int> Create(CreateCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var picture = new CustomerPicture(command.Name, command.Title, command.Alt);
            _context.CustomerPictures.Add(picture);
            await Save(cancellationToken);
            return picture.Id;
        }

        public async Task Edit(EditCustomerPictureDTO command, CancellationToken cancellationToken)
        {
            var picture = Get(command.Id);
            picture.Edit(command.Name, command.Title, command.Alt);
        }


        public async Task<CustomerPictureDTO> GetByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            return _context.CustomerPictures.Select(p =>
            new CustomerPictureDTO
            {
                Id= p.Id,
                Name = p.Name,
                Alt = p.Alt,
                Title = p.Title
            }).FirstOrDefault(p => p.CustomerId == customerId);
        }

        public async Task<EditCustomerPictureDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.CustomerPictures.Select(p =>
           new EditCustomerPictureDTO
           {
               Id = p.Id,
               Name = p.Name,
               Alt = p.Alt,
               Title = p.Title,
               CustomerID = p.Customer.Id
           }).FirstOrDefault(p => p.Id == id);
        }

        public async Task Reject(int id, CancellationToken cancellationToken)
        {
            var picture = Get(id);
            picture.Reject();
        }

        public async Task<List<CustomerPictureDTO>> SearchUnConfirmed(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.CustomerPictures
                .Where(p => !p.IsConfirmed)
                .Select(p =>
             new CustomerPictureDTO
             {
                 Id = p.Id,
                 Name = p.Name,
                 Alt = p.Alt,
                 Title = p.Title,
                 CustomerId = p.Customer.Id
             });

            if (searchModel.CustomerId > 0)
                query = query.Where(p => p.CustomerId == searchModel.CustomerId);

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<List<CustomerPictureDTO>> Serach(SearchCustomerPictureDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.CustomerPictures.Select(p =>
             new CustomerPictureDTO
             {
                 Id = p.Id,
                 Name = p.Name,
                 Alt = p.Alt,
                 Title = p.Title,
                 CustomerId = p.Customer.Id
             });

            if (searchModel.CustomerId > 0)
                query = query.Where(p => p.CustomerId == searchModel.CustomerId);

            return query.OrderByDescending(p => p.Id).ToList();
        }
    }
}

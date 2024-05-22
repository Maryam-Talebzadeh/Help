using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Admin;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;


namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AdminRepository : BaseRepository_EFCore<Admin>, IAdminRepository
    {
        private readonly HelpContext _context;

        public AdminRepository(HelpContext context) : base(context)
        {
            _context = context;
        }


        public async Task ChangePassword(ChangeAdminPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var Admin = Get(changePasswordModel.Id);
            Admin.ChangePassword(changePasswordModel.Password);
        }

        public async Task<int> Create(CreateAdminDTO command, CancellationToken cancellationToken)
        {
            var Admin = new Admin(command.EmployeeID, command.TerminationDateContract.ToGregorianDateTime(),command.FullName, command.UserName, command.Password, command.Email, command.Mobile, command.RoleId);
            _context.Admins.Add(Admin);
            await Save(cancellationToken);
            return Admin.Id;
        }


        public async Task Edit(EditAdminDTO command, CancellationToken cancellationToken)
        {
            var Admin = Get(command.Id);
            Admin.Edit(command.EmployeeID, command.TerminationDateContract.ToGregorianDateTime(),command.FullName, command.UserName, command.Email, command.Mobile);

        }

        public async Task<EditAdminDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Admins.Select(c =>
            new EditAdminDTO()
            {
                Id = c.Id,
                Email = c.Email,
                Mobile = c.Mobile,
                RoleId = c.RoleId,
                FullName = c.FullName,
                UserName = c.UserName,
                EmployeeID = c.EmployeeID,
                TerminationDateContract = c.TerminationDateContract.ToFarsi(),
                DateOfEmployeement = c.DateOfEmployeement.ToFarsi()
            }).FirstOrDefault(c => c.Id == id);
        }


        public async Task<List<AdminDTO>> Search(SearchAdminDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Admins.Select(c =>
            new AdminDTO()
            {
                Id = c.Id,
                FullName = c.FullName,
                RoleId = c.RoleId,
                UserName = c.UserName,
                Email = c.Email,
                Mobile = c.Mobile,
                EmployeeID = c.EmployeeID,
                TerminationDateContract = c.TerminationDateContract.ToFarsi(),
                DateOfEmployeement = c.DateOfEmployeement.ToFarsi()
            }); 

            if (!searchModel.FullName.IsNullOrEmpty())
                query = query.Where(c => c.FullName.Contains(searchModel.FullName));

            if (!searchModel.UserName.IsNullOrEmpty())
                query = query.Where(c => c.UserName.Contains(searchModel.UserName));

            if (!searchModel.Mobile.IsNullOrEmpty())
                query = query.Where(c => c.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(c => c.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}

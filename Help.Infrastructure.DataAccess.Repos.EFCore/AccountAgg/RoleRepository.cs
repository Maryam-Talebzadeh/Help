using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Role;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class RoleRepository : BaseRepository_EFCore<Role>, IRoleRepository
    {
        private readonly HelpContext _context;
        public RoleRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var role = new Role(command.Title);
            _context.Roles.Add(role);
        }

        public async Task Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var role = Get(command.Id);
            role.Edit(command.Title);
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Roles.Select(r =>
            new RoleDTO()
            {
                Id = r.Id,
                Title = r.Title
            }).ToList();
        }

        public async Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Roles.Select(r =>
           new EditRoleDTO()
           {
               Id = r.Id,
               Title = r.Title
           }).FirstOrDefault(r => r.Id == id);
        }
    }
}

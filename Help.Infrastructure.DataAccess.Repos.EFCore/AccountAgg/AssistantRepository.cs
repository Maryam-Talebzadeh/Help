using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Assistant;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.IdentityModel.Tokens;


namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AssistantRepository : BaseRepository_EFCore<Assistant>, IAssistantRepository
    {
        private readonly HelpContext _context;

        public AssistantRepository(HelpContext context) : base(context)
        {
            _context = context;
        }


        public async Task ChangePassword(ChangeAssistantPasswordDTO changePasswordModel, CancellationToken cancellationToken)
        {
            var assistant = Get(changePasswordModel.Id);
            assistant.ChangePassword(changePasswordModel.Password);
        }

        public async Task<int> Create(CreateAssistantDTO command, CancellationToken cancellationToken)
        {
            var assistant = new Assistant(command.EmployeeID, command.TerminationDateContract.ToGregorianDateTime(),command.FullName, command.UserName, command.Password, command.Email, command.Mobile, command.RoleId);
            _context.Assistants.Add(assistant);
            await Save(cancellationToken);
            return assistant.Id;
        }


        public async Task Edit(EditAssistantDTO command, CancellationToken cancellationToken)
        {
            var assistant = Get(command.Id);
            assistant.Edit(command.EmployeeID, command.TerminationDateContract.ToGregorianDateTime(),command.FullName, command.UserName, command.Email, command.Mobile);

        }

        public async Task<EditAssistantDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Assistants.Select(c =>
            new EditAssistantDTO()
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


        public async Task<List<AssistantDTO>> Search(SearchAssistantDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Assistants.Select(c =>
            new AssistantDTO()
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
            }); ;

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

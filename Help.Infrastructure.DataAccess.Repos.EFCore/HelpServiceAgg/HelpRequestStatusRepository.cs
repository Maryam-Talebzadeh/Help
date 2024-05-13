using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequestStatus;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class HelpRequestStatusRepository : BaseRepository_EFCore<HelpRequestStatus>, IHelpRequestStatusRepository
    {
        private readonly HelpContext _context;

        public HelpRequestStatusRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Create(CreateHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            var status = new HelpRequestStatus(command.Title, command.Description);
            await _context.HelpRequestStatuses.AddAsync(status);
        }

        public async Task Edit(EditHelpRequestStatusDTO command, CancellationToken cancellationToken)
        {
            var status = Get(command.Id);
            status.Edit(command.Title, command.Description);
        }

        public async Task<List<HelpRequestStatusDTO>> GetAll( CancellationToken cancellationToken)
        {
            return _context.HelpRequestStatuses.Select(s =>
            new HelpRequestStatusDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                
            }).OrderBy(s => s.Title).ToList();
        }

        public async Task<EditHelpRequestStatusDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _context.HelpRequestStatuses.Select(s =>
            new EditHelpRequestStatusDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            }).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

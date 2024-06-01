using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.AccountAgg.Data;
using Help.Domain.Core.AccountAgg.DTOs.Skill;
using Help.Domain.Core.AccountAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class SkillRepository : BaseRepository_EFCore<Skill>, ISkillRepository
    {
        private readonly HelpContext _context;

        public SkillRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Create(CreateSkillDTO command, CancellationToken cancellationToken)
        {
            var skill = new Skill(command.CustomerId, command.HelpServiceId);
            _context.Add(skill);
        }

        public async Task<List<SkillDTO>> GetAllByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            return _context.Skills.Where(s => s.CustomerId == customerId)
                .Select(s =>
                new SkillDTO
                {
                    Id = s.Id,
                    CustomerId = s.CustomerId,
                    HelpServiceId = s.HelpServiceId,
                    HelpServiceName = s.HelpService.Title
                }).ToList();
        }
    }
}

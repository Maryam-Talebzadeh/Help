using Base_Framework.General;
using Base_Framework.Infrastructure.DataAccess;
using Help.Domain.Core.HelpServiceAgg.Data;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using Help.Domain.Core.HelpServiceAgg.DTOs.Skill;
using Help.Domain.Core.HelpServiceAgg.Entities;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace Help.Infrastructure.DataAccess.Repos.EFCore.HelpServiceAgg
{
    public class SkillRepository : BaseRepository_EFCore<Skill>, ISkillRepository
    {
        private readonly HelpContext _context;

        public SkillRepository(HelpContext context) : base(context)
        {
            _context = context;
        }

        public async Task Confirm(int id, CancellationToken cancellationToken)
        {
            var skill = Get(id);
            skill.Confirm();
        }

        public async Task Create(CreateSkillDTO command, CancellationToken cancellationToken)
        {
            var skill = new Skill(command.Title, command.Description, command.Level, command.ServiceId, command.CustomerId);
            _context.Skills.Add(skill);
        }

        public async Task Edit(EditSkillDTO command, CancellationToken cancellationToken)
        {
            var skill = Get(command.Id);
            skill.Edit(command.Title, command.Description, command.Level, command.ServiceId);
        }

        public async Task<List<SkillDTO>> GetBy(int customerId, CancellationToken cancellationToken)
        {
            return _context.Skills.Where(s => s.CustomerId == customerId && s.IsConfirmed)
                .Select(s => new SkillDTO()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Level = s.Level,
                    Description = s.Description,
                    CreationDate = s.CreationDate.ToFarsi(),
                    CustomerId = s.CustomerId,
                    HelpService = new IdTitleHelpServiceDTO()
                    {
                        Id = s.HelpService.Id,
                        Title = s.HelpService.Title
                    }
                }).ToList();
        }

        public async Task<EditSkillDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            return _context.Skills.Select(s =>
           new EditSkillDTO()
           {
               Id = s.Id,
               Title = s.Title,
               Level = s.Level,
               Description = s.Description,
               CustomerId = s.CustomerId,
               ServiceId = s.ServiceId
           }).FirstOrDefault(s => s.Id == id);
        }

        public async Task<List<SkillDTO>> SearchUnConfirmed(SearchSkillDTO searchModel, CancellationToken cancellationToken)  //Just for admin
        {
            var query = _context.Skills.Where(s => !s.IsConfirmed)
                 .Select(s => new SkillDTO()
                 {
                     Id = s.Id,
                     Title = s.Title,
                     Level = s.Level,
                     Description = s.Description,
                     CreationDate = s.CreationDate.ToFarsi(),
                     CustomerId = s.CustomerId,
                     HelpService = new IdTitleHelpServiceDTO()
                     {
                         Id = s.HelpService.Id,
                         Title = s.HelpService.Title
                     }
                 });

            if (searchModel.CustomerId > 0)
                query = query.Where(s => s.CustomerId == searchModel.CustomerId);

            return query.OrderByDescending(s => s.CreationDate).ToList();
        }
    }
}

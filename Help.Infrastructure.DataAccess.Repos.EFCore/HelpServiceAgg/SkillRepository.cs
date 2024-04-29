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

        public void Confirm(long id)
        {
            var skill = Get(id);
            skill.Confirm();
        }

        public void Create(CreateSkillDTO command)
        {
            var skill = new Skill(command.Title, command.Description, command.Level, command.ServiceId, command.CustomerId);
            _context.Skills.Add(skill);
        }

        public void Edit(EditSkillDTO command)
        {
            var skill = Get(command.Id);
            skill.Edit(command.Title, command.Description, command.Level, command.ServiceId);
        }

        public List<SkillDTO> GetBy(long customerId)
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

        public EditSkillDTO GetDetails(long id)
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
           }).SingleOrDefault(s => s.Id == id);
        }

        public List<SkillDTO> SearchUnConfirmed(SearchSkillDTO searchModel)  //Just for admin
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

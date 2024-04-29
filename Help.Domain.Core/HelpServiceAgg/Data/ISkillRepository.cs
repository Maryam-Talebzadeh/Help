using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Skill;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ISkillRepository : IRepository<Skill>
    {
        void Confirm(long id);
        void Create(CreateSkillDTO command);
        void Edit(EditSkillDTO command);
        EditSkillDTO GetDetails(long id);
        List<SkillDTO> SearchUnConfirmed(SearchSkillDTO searchModel);
        List<SkillDTO> GetBy(long customerId);
    }
}

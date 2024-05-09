using Base_Framework.Domain.Core.Contracts;
using Help.Domain.Core.HelpServiceAgg.DTOs.Skill;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Data
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task Confirm(int id, CancellationToken cancellationToken);
        Task Create(CreateSkillDTO command, CancellationToken cancellationToken);
        Task Edit(EditSkillDTO command, CancellationToken cancellationToken);
        Task<EditSkillDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<SkillDTO>> SearchUnConfirmed(SearchSkillDTO searchModel, CancellationToken cancellationToken);
        Task<List<SkillDTO>> GetBy(int customerId, CancellationToken cancellationToken);
    }
}

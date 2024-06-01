

using Help.Domain.Core.AccountAgg.DTOs.Skill;

namespace Help.Domain.Core.AccountAgg.DTOs.Customer
{
    public class EditCustomerDTO : CreateCustomerDTO
    {
        public int Id { get; set; }
        public List<SkillDTO>? Skills { get; set; }
        public List<int>? SkillIds { get; set; }
    }
}

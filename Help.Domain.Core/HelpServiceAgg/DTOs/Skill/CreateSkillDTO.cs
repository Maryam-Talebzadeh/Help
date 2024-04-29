

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Skill
{
    public class CreateSkillDTO 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Int16 Level { get; set; }
        public long ServiceId { get; set; }
        public long CustomerId { get; set; }
    }
}

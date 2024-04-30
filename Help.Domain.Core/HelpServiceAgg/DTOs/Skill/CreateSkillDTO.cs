

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Skill
{
    public class CreateSkillDTO 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Int16 Level { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
    }
}

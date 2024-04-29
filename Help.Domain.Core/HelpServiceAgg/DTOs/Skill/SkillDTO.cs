

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.Skill
{
    public class SkillDTO
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Int16 Level { get; set; }
        public IdTitleHelpServiceDTO HelpService { get; set; }
        public long CustomerId { get; set; } //Temporary
    }
}

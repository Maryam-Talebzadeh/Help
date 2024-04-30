

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class CreateChildHelpServiceCategoryDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}

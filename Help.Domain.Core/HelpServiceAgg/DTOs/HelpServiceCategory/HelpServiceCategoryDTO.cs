

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class HelpServiceCategoryDTO
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public HelpServiceCategoryDTO Parent { get;  set; }
        public List<HelpServiceCategoryDTO> Children { get; set; }
        public List<HelpServiceDTO> HelpServices { get; set; }
    }
}

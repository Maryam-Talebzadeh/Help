

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory
{
    public class HelpServiceCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string CreationDate { get; set; }
        public HelpServiceCategoryDTO Parent { get;  set; }
        public List<IdTitleCategoryDTO> Children { get; set; }
        public List<HelpServiceDTO> HelpServices { get; set; }
    }
}

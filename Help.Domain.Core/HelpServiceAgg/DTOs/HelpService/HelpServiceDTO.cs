using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpService
{
    public class HelpServiceDTO
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public IdTitleCategoryDTO Category { get; set; }
    }
}

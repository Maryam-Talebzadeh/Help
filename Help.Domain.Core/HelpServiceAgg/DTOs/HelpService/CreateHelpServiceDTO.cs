

using Help.Domain.Core.HelpServiceAgg.DTOs.HelpServiceCategory;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpService
{
    public class CreateHelpServiceDTO
    {
        public string Title { get; set; }
        public string Description { get;  set; }
        public string Slug { get;  set; }
        public string Tags { get;  set; }
        public int CategoryId { get; set; }
        public int PictureId { get; set; }
        public List<IdTitleCategoryDTO> Categories { get; set; }
    }
}

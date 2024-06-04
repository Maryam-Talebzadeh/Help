using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;

namespace Help.EndPoint.WebApi.DTOs
{
    public class CategoryWithServicesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public List<HelpServiceDTO> Services { get; set; }
    }
}

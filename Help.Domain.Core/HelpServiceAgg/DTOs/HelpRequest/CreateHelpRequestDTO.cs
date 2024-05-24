

using Base_Framework.Domain.Services;
using Help.Domain.Core.HelpServiceAgg.DTOs.HelpService;
using System.ComponentModel.DataAnnotations;

namespace Help.Domain.Core.HelpServiceAgg.DTOs.HelpRequest
{
    public class CreateHelpRequestDTO
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ExpirationDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public double ProposedPrice { get; set; }
        public List<HelpServiceDTO>? Services { get; set; }
        public bool IsDone { get; set; }
    }
}



namespace Help.Domain.Core.AccountAgg.DTOs.HelpService
{
    public class CreateHelpServiceDTO
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Tags { get; private set; }
    }
}

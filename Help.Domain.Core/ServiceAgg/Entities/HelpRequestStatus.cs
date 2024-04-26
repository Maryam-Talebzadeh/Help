using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class HelpRequestStatus : BaseEntity
    {
        public HelpRequestStatus(string title, string? description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; }
        public string Description { get; set; }

        public void Edit(string title, string? description)
        {
            Title = title;
            Description = description;
        }
    }
}

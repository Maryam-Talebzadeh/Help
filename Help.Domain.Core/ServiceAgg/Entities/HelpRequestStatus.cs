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
        public string Description { get; private set; }

        #region Navigation Properties

        public List<HelpRequest> HelpRequests { get; private set; }

        #endregion

        public void Edit(string title, string? description)
        {
            Title = title;
            Description = description;
        }
    }
}

using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class ServiceCategory : BaseEntity
    {
        public ServiceCategory(string title, string description, long parentId)
        {
            Title = title;
            Description = description;
            ParentId = parentId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public long ParentId { get; private set; }

        #region Navigation Properties

        public List<Service> Services { get; private set; }
        public ServiceCategory Parrent { get; private set; }

        #endregion

        public void Edit(string title, string description, long parentId)
        {
            Title = title;
            Description = description;
            ParentId = parentId;
        }
    }
}

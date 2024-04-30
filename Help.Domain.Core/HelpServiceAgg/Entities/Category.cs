using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class Category : BaseEntity
    {
        public Category(string title, string description, int parentId)
        {
            Title = title;
            Description = description;
            ParentId = parentId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int ParentId { get; private set; }

        #region Navigation Properties

        public List<HelpServiceCategory> Services { get; private set; }
        public Category Parent { get; private set; }
        public List<Category> Children { get; private set; }

        #endregion

        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

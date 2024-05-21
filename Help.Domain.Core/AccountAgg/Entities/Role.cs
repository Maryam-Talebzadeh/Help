using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Role : BaseEntity
    {
        public Role(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }

        #region Navigation Properties

        public List<Customer> Customers { get; private set; }

        #endregion

        public void Edit(string title)
        {
            Title = title;
        }
    }
    
}

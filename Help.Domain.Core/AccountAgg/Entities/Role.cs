

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Role
    {
        public Byte Id { get; private set; }
        public string Title { get; private set; }

        #region Navigation Property

        public List<CustomerRole> CustomerRoles { get; private set; }

        #endregion
    }
}

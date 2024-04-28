using Help.Domain.Core.ServiceAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerRole
    {
        public long Id { get; private set; }
        public long CustomerId { get; private set; }
        public Byte RoleId { get; private set; }

        #region Navigation Properties

        public List<Comment> Comments { get; private set; }
        public Customer Customer { get; private set; }
        public Role Role { get; private set; }

        #endregion
    }
}

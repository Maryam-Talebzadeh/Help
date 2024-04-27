

using Help.Domain.Core.ServiceAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerRole
    {
        public long Id { get; private set; }
        public string Title { get; private set; }

        #region Navigation Properties

        public List<Comment> Comments { get; private set; }

        #endregion
    }
}

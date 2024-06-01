using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.HelpServiceAgg.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(int customerId, int helpServiceId)
        {
            CustomerId = customerId;
            HelpServiceId = helpServiceId;
        }

        public int CustomerId { get; private set; }
        public int HelpServiceId { get; private set; }

        #region NavigationProperties

        public Customer Customer { get; private set; }
        public HelpService HelpService { get; private set; }

        #endregion
    }
}

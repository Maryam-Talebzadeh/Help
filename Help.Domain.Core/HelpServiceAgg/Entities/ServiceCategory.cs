using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class ServiceCategory 
    {     
        public long Id { get; private set; }
        public long ServiceId { get; private set; }
        public long CategoryId { get; private set; }

        #region Relations

        public Service Service { get; private set; }
        public Category Category { get; private set; }

        #endregion
    }
}

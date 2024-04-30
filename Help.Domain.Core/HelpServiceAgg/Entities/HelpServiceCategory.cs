using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpServiceCategory 
    {     
        public int Id { get; private set; }
        public int ServiceId { get; private set; }
        public int CategoryId { get; private set; }

        #region Relations

        public HelpService HelpService { get; private set; }
        public Category Category { get; private set; }

        #endregion
    }
}

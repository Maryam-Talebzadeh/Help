using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpServicePicture : Picture
    {
        public HelpServicePicture(string name, string title, string alt, int serviceId) : base(name, title, alt)
        {
            ServiceId = serviceId;
        }

        public int ServiceId { get; private set; }

        #region Navigation Properties

        public HelpService HelpService { get; private set; }

        #endregion
    }
}

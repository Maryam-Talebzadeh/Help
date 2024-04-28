using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class ServicePicture : Picture
    {
        public ServicePicture(string name, string title, string alt, long serviceId) : base(name, title, alt)
        {
            ServiceId = serviceId;
        }

        public long ServiceId { get; private set; }

        #region Navigation Properties

        public HelpService HelpService { get; private set; }

        #endregion
    }
}

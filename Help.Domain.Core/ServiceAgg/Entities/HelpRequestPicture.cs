using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class HelpRequestPicture : Picture
    {
        public HelpRequestPicture(string name, string title, string alt, long helpRequestId) :base(name, title, alt)
        {
            HelpRequestId = helpRequestId;
        }

        public long HelpRequestId { get; private set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }

        #endregion

    }
}

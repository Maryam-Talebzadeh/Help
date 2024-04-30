using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpRequestPicture : Picture
    {
        public HelpRequestPicture(string name, string title, string alt, int helpRequestId) :base(name, title, alt)
        {
            HelpRequestId = helpRequestId;
        }

        public int HelpRequestId { get; private set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }

        #endregion

    }
}

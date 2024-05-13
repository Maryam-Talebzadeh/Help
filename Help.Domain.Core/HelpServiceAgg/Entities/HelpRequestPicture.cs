using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpRequestPicture : Picture
    {
        public HelpRequestPicture(string name, string title, string alt, int helpRequestId) : base(name, title, alt)
        {
            HelpRequestId = helpRequestId;
        }

        public int HelpRequestId { get; private set; }

        public bool IsConfirmed { get; protected set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }

        #endregion

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
            IsConfirmed = false;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Reject()
        {
            IsConfirmed = false;
        }

    }
}

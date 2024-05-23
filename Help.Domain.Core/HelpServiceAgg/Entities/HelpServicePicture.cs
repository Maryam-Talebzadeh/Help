using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpServicePicture : Picture
    {
        public HelpServicePicture(string name, string title, string alt) : base(name, title, alt)
        {
        }


        #region Navigation Properties

        public HelpService HelpService { get; private set; }

        #endregion

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}

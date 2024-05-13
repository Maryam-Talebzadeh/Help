using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.AccountAgg.Entities
{
    public class CustomerPicture : Picture
    {
        public CustomerPicture(string name, string title, string alt) : base(name, title, alt)
        {
            
        }


        #region Navigation Properties

        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}

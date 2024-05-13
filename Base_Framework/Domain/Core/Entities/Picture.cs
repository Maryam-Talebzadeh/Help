

namespace Base_Framework.Domain.Core.Entities
{
    public class Picture : BaseEntity
    {
        public Picture(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }

        public string Name { get; protected set; }
        public string Title { get; protected set; }
        public string Alt { get; protected set; }
      
    }
}

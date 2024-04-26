

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

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}

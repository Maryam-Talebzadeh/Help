

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

        public string Name { get; internal set; }
        public string Title { get; internal set; }
        public string Alt { get; internal set; }

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}

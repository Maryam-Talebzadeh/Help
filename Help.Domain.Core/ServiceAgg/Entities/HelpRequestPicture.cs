using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class HelpRequestPicture : BaseEntity
    {
        public HelpRequestPicture(string name, string title, string alt, long helpRequestId)
        {
            Name = name;
            Title = title;
            Alt = alt;
            HelpRequestId = helpRequestId;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
        public long HelpRequestId { get; private set; }

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}



using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class ServicePicture : BaseEntity
    {
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
        public long ServiceId { get; private set; }
    }
}

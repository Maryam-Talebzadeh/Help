

namespace Base_Framework.Domain.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsRemoved = false;
            CreationDate = DateTime.Now;
        }

        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}

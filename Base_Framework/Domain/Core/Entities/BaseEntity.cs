

namespace Base_Framework.Domain.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsRemoved = false;
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public bool IsRemoved { get; protected set; }
        public DateTime CreationDate { get; protected set; }

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

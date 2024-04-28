using Base_Framework.Domain.Core.Entities;
using System.Linq.Expressions;

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        public bool IsExist(Expression<Func<T, bool>> expression);
        public void Save();
    }
}

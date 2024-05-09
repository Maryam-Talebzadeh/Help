using Base_Framework.Domain.Core.Entities;
using System.Linq.Expressions;

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
         Task<bool> IsExist(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task Save(CancellationToken cancellationToken);
        Task Remove(int id, CancellationToken cancellationToken);
        Task Restore(int id, CancellationToken cancellationToken);
        Task<int> Count(CancellationToken cancellationToken);
    }
}

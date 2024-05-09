using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Base_Framework.Infrastructure.DataAccess
{
    public class BaseRepository_EFCore<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository_EFCore(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return _context.Set<T>().Any(expression);
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            _context.SaveChangesAsync();
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            var entity = Get(id);
            entity.Remove();
        }

        public void Restore(int id)
        {
            var entity = Get(id);
            entity.Restore();
        }

    }
}

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

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }
    }
}

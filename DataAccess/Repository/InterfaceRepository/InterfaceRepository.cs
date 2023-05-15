using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.InterfaceRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Represents any generic Model we will operate on, for example Category.
        IEnumerable<T> GetAll();
        T? GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

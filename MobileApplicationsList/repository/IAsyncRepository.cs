using System.Linq.Expressions;

namespace MobileApplicationsList.repository
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync<TId>(TId id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);

        Task<int> CountAsync();
        Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
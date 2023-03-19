using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MobileApplicationsList.repository
{

    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected DbContext _applicationDataContext;

        public BaseRepository(DbContext applicationDbContext)
        {
            _applicationDataContext = applicationDbContext;
        }

        public async Task<T?> GetByIdAsync<TId>(TId id)
        {
            return await _applicationDataContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _applicationDataContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _applicationDataContext.Set<T>().Add(entity);
            await _applicationDataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _applicationDataContext.Set<T>().Remove(entity);
            return await _applicationDataContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _applicationDataContext.Set<T>(). CountAsync();
        }

        public Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

}
namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase<T > 
{
    ValueTask<IQueryable<T>> GetAllAsync();
    ValueTask<T> GetByIdAsync(Guid id);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<T> UpdateAsync(T entity);
    ValueTask<T> DeleteByIdAsync(Guid id);
    ValueTask<T> DeleteAsync(T entity);
}
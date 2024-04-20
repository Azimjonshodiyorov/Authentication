namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase<T, in TId > 
{
    ValueTask<IQueryable<T>> GetAllAsync();
    ValueTask<T> GetByIdAsync(TId id);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<T> UpdateAsync(T entity);
    ValueTask<T> DeleteByIdAsync(TId id);
    ValueTask<T> DeleteAsync(T entity);
}
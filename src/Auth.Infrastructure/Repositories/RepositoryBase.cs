using Auth.Core.Common;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: BaseEntity<Guid>
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask<IQueryable<T>> GetAllAsync()
        {
            return this._dbContext.Set<T>();
        }

        public async ValueTask<T> GetByIdAsync(Guid id)
        {
            return await this._dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async ValueTask<T> CreateAsync(T entity)
        {
            var create = await this._dbContext.Set<T>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();
            return create.Entity;
        }

        public async ValueTask<T> UpdateAsync(T entity)
        {
            var update =  this._dbContext.Set<T>().Update(entity);
            await this._dbContext.SaveChangesAsync();
            return update.Entity;
        }

        public async ValueTask<T> DeleteByIdAsync(Guid id)
        {
            var delete = await GetByIdAsync(id);
            this._dbContext.Set<T>().Remove(delete);
            await this._dbContext.SaveChangesAsync();
            return delete;

        }

        public async ValueTask<T> DeleteAsync(T entity)
        {
            return this._dbContext.Set<T>().Remove(entity).Entity;
        }
    }
}

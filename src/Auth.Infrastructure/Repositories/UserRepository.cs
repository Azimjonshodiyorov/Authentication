using Auth.Core.Entities;
using Auth.Infrastructure.DataContext;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User , Guid> , IUserRepository<User , Guid>
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<User?> GetUserByEmailAsync(string email)
    {
        return await this._dbContext.Users
            .Include(x => x.FirstName)
            .Include(x => x.LastName)
            .Include(x => x.Role)
            .Include(x => x.RefreshTokens)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
    

    public async ValueTask<User?> GetUserByRefreshTokenAsync(string refreshToken)
    {
        return await this._dbContext.Users
            .Include(x => x.FirstName)
            .Include(x => x.LastName)
            .Include(x => x.Role)
            .Include(x => x.RefreshTokens)
            .FirstOrDefaultAsync(x => x.RefreshTokens
                .Any(r=>r.Token == refreshToken));
    }
}
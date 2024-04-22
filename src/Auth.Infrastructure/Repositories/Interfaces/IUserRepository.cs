using Auth.Core.Entities;

namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    ValueTask<User?> GetUserByEmailAsync(string email);
    ValueTask<User?> GetUserByRefreshTokenAsync(string refreshToken);
}
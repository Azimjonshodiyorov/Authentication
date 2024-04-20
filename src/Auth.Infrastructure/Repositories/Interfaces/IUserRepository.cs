namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IUserRepository<T , in TId> : IRepositoryBase<T , TId>
{
    ValueTask<T?> GetUserByEmailAsync(string email);
    ValueTask<T?> GetUserByRefreshTokenAsync(string refreshToken);
}
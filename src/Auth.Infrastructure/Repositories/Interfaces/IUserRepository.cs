namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IUserRepository<T > : IRepositoryBase<T>
{
    ValueTask<T?> GetUserByEmailAsync(string email);
    ValueTask<T?> GetUserByRefreshTokenAsync(string refreshToken);
}
using Auth.Core.Enum;

namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository<T> : IRepositoryBase<T>
{
    ValueTask<T> GetRoleByValueAsync(RoleName roleName);
}
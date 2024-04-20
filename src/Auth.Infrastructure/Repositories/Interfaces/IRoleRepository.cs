using Auth.Core.Enum;

namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository<T , in TId> : IRepositoryBase<T , TId>
{
    ValueTask<T> GetRoleByValueAsync(RoleName roleName);
}
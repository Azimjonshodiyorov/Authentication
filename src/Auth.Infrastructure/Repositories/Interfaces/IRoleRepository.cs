using Auth.Core.Entities;
using Auth.Core.Enum;

namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository : IRepositoryBase<Role>
{
    ValueTask<Role> GetRoleByValueAsync(RoleName roleName);
}
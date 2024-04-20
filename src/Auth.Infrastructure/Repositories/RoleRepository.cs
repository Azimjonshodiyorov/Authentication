using Auth.Core.Entities;
using Auth.Core.Enum;
using Auth.Infrastructure.DataContext;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories;

public class RoleRepository : RepositoryBase<Role , Guid> , IRoleRepository<Role , Guid>
{
    private readonly AppDbContext _dbContext;

    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Role> GetRoleByValueAsync(RoleName roleName)
    {
        return await this._dbContext.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);
    }
}
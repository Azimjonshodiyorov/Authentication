using Auth.Core.Common;
using Auth.Core.Entities;
using Auth.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; init; }
    public DbSet<Role> Roles { get; init; }
    public DbSet<RefreshToken> RefreshTokens { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new RoleConfiguration())
            .ApplyConfiguration(new RefreshTokenConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    /*public   Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entity in ChangeTracker
                     .Entries()
                     .Where(x => x is { Entity: AuditableEntity<T>, State: EntityState.Modified })
                     .Select(x => x.Entity)
                     .Cast<AuditableEntity<T>>()) 
        {
            entity.UpdateAt = DateTime.Now;
        }
        
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }*/
}
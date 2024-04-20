using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(x => x.RoleName)
            .IsUnique();

        builder.Property(x => x.RoleName)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();
    }
}
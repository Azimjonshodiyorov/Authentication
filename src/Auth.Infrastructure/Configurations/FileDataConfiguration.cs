using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Configurations;

public class FileDataConfiguration : IEntityTypeConfiguration<FileData>
{
    public void Configure(EntityTypeBuilder<FileData> builder)
    {
        builder.HasIndex(fd => fd.FileName)
            .IsUnique();

        builder.Property(fd => fd.BucketName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(fd => fd.FileName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(fd => fd.FileType)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(fd => fd.FileSize)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.FileDatas)
            .HasForeignKey(x => x.UserId);
    }
}
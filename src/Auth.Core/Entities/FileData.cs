using Auth.Core.Common;

namespace Auth.Core.Entities;

public class FileData : AuditableEntity<Guid>
{
    public string BucketName { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public ulong FileSize { get; set; }
    
    //Relations

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
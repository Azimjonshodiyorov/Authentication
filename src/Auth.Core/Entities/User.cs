using Auth.Core.Common;

namespace Auth.Core.Entities;

public class User : AuditableEntity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    
    //Relations
    public virtual required  Role Role { get; set; }
    public Guid RoleId { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    
    
    public virtual ICollection<FileData> FileDatas { get; set; }
}
using Auth.Core.Common;

namespace Auth.Core.Entities;

public class User : AuditableEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    //Relations
    public virtual Role Role { get; set; }
    public Guid RoleId { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
}
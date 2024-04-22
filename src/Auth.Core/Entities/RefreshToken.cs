using Auth.Core.Common;

namespace Auth.Core.Entities;

public class RefreshToken : AuditableEntity<Guid>
{
    public required string Token { get; set; }
    public required DateTime Expires { get; set; }
    
    //Relations

    public virtual required User User { get; set; }
    public Guid UserId { get; set; }
}
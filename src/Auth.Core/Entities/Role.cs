using Auth.Core.Common;
using Auth.Core.Enum;

namespace Auth.Core.Entities;

public class Role : AuditableEntity<Guid>
{
    public required RoleName RoleName { get; set; }
    
    //Relations
    public virtual ICollection<User> Users { get; set; }
}
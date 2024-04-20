namespace Auth.Core.Common;
    public abstract class AuditableEntity<T> : BaseEntity<T>
    {
           public DateTime CreateAt { get; set; }
           public DateTime UpdateAt { get; set; }
    }


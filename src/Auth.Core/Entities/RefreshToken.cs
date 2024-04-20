namespace Auth.Core.Entities;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    
    //Relations

    public virtual User User { get; set; }
    public Guid UserId { get; set; }
}
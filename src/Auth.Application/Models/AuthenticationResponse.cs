namespace Auth.Application.Models;

public record AuthenticationResponse(JwtToken JwtToken , CookieToken CookieToken);
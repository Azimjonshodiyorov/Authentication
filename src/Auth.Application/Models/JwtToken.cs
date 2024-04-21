namespace Auth.Application.Models;

public record JwtToken(string accessToken , string type = "Bearer");

    

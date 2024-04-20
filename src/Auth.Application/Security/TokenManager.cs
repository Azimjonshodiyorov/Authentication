using System.Security.Cryptography;
using Auth.Application.Security.Interfaces;
using Auth.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Auth.Application.Security;

public class TokenManager : ITokenManager 
{
    private readonly IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async ValueTask<string> GenerateAccessToken(User user)
    {
        return null;
    }

    public RefreshToken GeneratRefreshToken(User user)
    {
        return new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(256)),
            Expires = DateTime.UtcNow.AddDays(
                int.Parse(_configuration.GetSection("Authentication:RefreshTokenLifetimeDays").Value!)),
            User = user
        };
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Auth.Application.Security.Interfaces;
using Auth.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.RoleName.ToString())
        };
        
        

        var settings = _configuration.GetSection("Authentication:Key").Value!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var descriptore = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Authentication:TokenLifeTimeMin"])),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = credentials,
            
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(descriptore);
        return handler.WriteToken(token);
    }

    public RefreshToken GeneratRefreshToken(User user)
    {
        return new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(256)),
            Expires = DateTime.UtcNow.AddDays(
                int.Parse(_configuration["Authentication:RefreshTokenLifetimeDays"])),
            User = user
        };
    }
}
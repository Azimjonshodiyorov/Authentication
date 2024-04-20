using Auth.Core.Entities;

namespace Auth.Application.Security.Interfaces;

public interface ITokenManager
{
    ValueTask<string> GenerateAccessToken(User user);
    RefreshToken GeneratRefreshToken(User user);
}
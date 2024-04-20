using Auth.Application.Security.Interfaces;
using Auth.Core.Entities;

namespace Auth.Application.Security;

public class TokenManager : ITokenManager 
{
    public async ValueTask<string> GenerateAccessToken(User user)
    {
        throw new NotImplementedException();
    }

    public RefreshToken GeneratRefreshToken(User user)
    {
        throw new NotImplementedException();
    }
}
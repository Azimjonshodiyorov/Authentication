using System.Diagnostics;
using Auth.Application.Services.Interfaces;
using Auth.Core.Entities;

namespace Auth.Application.Services;

public class RefreshTokenService : IRefreshTokenService
{
    public async ValueTask ValidateAndRemoveRefreshToken(User user, string oldRefreshToken)
    {
        var userRefreshToken = user.RefreshTokens.First(x => x.Token == oldRefreshToken);

        if (userRefreshToken.Expires < DateTime.Now)
        {
            throw new UnreachableException("Refresh token is valid");
        }

        user.RefreshTokens.Remove(userRefreshToken);
    }
}
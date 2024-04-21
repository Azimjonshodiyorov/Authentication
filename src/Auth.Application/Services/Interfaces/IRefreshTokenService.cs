using Auth.Core.Entities;

namespace Auth.Application.Services.Interfaces;

public interface IRefreshTokenService
{
    ValueTask ValidateAndRemoveRefreshToken(User user, string oldRefreshToken);
}
using Auth.Application.Exceptions;
using Auth.Application.Models;
using Auth.Application.Security.Interfaces;
using Auth.Application.Services.Interfaces;
using Auth.Core.Entities;
using Auth.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Auth.Application.Commands.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand , AuthenticationResponse>
{
    private readonly ITokenManager _tokenManager;
    private readonly IUserRepository<User> _userRepository;
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshCommandHandler(
        ITokenManager tokenManager ,
        IUserRepository<User > userRepository ,
        IRefreshTokenService refreshTokenService)
    {
        _tokenManager = tokenManager;
        _userRepository = userRepository;
        _refreshTokenService = refreshTokenService;
    }
    public async Task<AuthenticationResponse> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var user = await this._userRepository.GetUserByRefreshTokenAsync(request.RefreshToken)
                   ?? throw new UnauthorizedException("Refersh Token isn't valid");

        await this._refreshTokenService.ValidateAndRemoveRefreshToken(user, request.RefreshToken);
        var accessToken = await this._tokenManager.GenerateAccessToken(user);
        var refreshToken =  this._tokenManager.GeneratRefreshToken(user);
        user.RefreshTokens.Add(refreshToken);
        await this._userRepository.UpdateAsync(user);

        return new AuthenticationResponse(
            new JwtToken(accessToken),
            new CookieToken(refreshToken.Token, refreshToken.Expires));

    }
}
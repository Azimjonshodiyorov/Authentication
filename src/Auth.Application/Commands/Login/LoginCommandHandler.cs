using Auth.Application.Exceptions;
using Auth.Application.Models;
using Auth.Application.Security.Interfaces;
using Auth.Core.Entities;
using Auth.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Auth.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand , AuthenticationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenManager _tokenManager;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(
        IUserRepository userRepository ,
        IPasswordManager passwordManager , 
        ITokenManager tokenManager , 
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _tokenManager = tokenManager;
        _configuration = configuration;
    }
    public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await this._userRepository.GetUserByEmailAsync(request.Email);

        if (user is null ||
            !this._passwordManager.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new AccessDeniedException(nameof(User), request.Email);
        }

        var refreshTokenMaxCount =
            int.Parse(this._configuration.GetSection("Authentication:RefreshTokenMaxCount").Value!);

        if (user.RefreshTokens.Count >= refreshTokenMaxCount)
        {
            var oldestRefreshToken = user.RefreshTokens.OrderBy(x => x.Expires).First();
            user.RefreshTokens.Remove(oldestRefreshToken);
        }

        var accessToken = await this._tokenManager.GenerateAccessToken(user);
        var refreshToken =  this._tokenManager.GeneratRefreshToken(user);
        
        user.RefreshTokens.Add(refreshToken);
        await this._userRepository.UpdateAsync(user);

        return new AuthenticationResponse(
            new JwtToken(accessToken),
            new CookieToken(refreshToken.Token, refreshToken.Expires));
    }
}
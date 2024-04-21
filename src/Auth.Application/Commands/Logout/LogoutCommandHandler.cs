using Auth.Application.Exceptions;
using Auth.Application.Services.Interfaces;
using Auth.Core.Entities;
using Auth.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Auth.Application.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand , Unit>
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IRefreshTokenService _tokenService;

    public LogoutCommandHandler(IUserRepository<User> userRepository , IRefreshTokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var user = await this._userRepository.GetUserByRefreshTokenAsync(request.RefreshToken) ??
                   throw new UnauthorizedException("Refresh token isn't valid");

        await this._tokenService.ValidateAndRemoveRefreshToken(user, request.RefreshToken);
        await this._userRepository.UpdateAsync(user);

        return await Unit.Task;
    }
}
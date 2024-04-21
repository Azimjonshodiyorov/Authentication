using MediatR;

namespace Auth.Application.Commands.Logout;

public record LogoutCommand(string RefreshToken) : IRequest<Unit>;
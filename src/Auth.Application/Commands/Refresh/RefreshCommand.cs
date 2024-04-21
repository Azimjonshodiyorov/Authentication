using Auth.Application.Models;
using MediatR;

namespace Auth.Application.Commands.Refresh;

public record RefreshCommand(string RefreshToken) : IRequest<AuthenticationResponse>;

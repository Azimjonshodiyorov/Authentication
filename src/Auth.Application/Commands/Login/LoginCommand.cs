using System.ComponentModel.DataAnnotations;
using Auth.Application.Models;
using MediatR;

namespace Auth.Application.Commands.Login;

public class LoginCommand : IRequest<AuthenticationResponse>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string  Password { get; set; }
}
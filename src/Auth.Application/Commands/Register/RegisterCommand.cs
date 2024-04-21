using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Auth.Application.Commands.Register;

public record RegisterCommand : IRequest<Guid>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; set; }
}
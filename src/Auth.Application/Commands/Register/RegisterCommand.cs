using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Auth.Application.Commands.Register;

public record RegisterCommand : IRequest<Guid>
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; set; }
}
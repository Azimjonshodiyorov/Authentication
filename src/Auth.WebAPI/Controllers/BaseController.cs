using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
    
    protected string? CurrentUserId() => 
        User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    
}
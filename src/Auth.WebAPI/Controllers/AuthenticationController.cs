using MediatR;

namespace Auth.WebAPI.Controllers;

public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) 
        : base(mediator)
    {
    }
}
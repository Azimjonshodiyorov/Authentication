using System.Net;
using Auth.Application.Commands.Login;
using Auth.Application.Commands.Register;
using Auth.Application.Models;
using Auth.WebAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers;

public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) 
        : base(mediator)
    {
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(Guid) , StatusCodes.Status201Created)]
    public async Task<ActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(result.ToString(), result);
    }


    [HttpPost("login")]
    [ProducesResponseType(typeof(JwtToken) , StatusCodes.Status201Created)]
    public async Task<ActionResult<JwtToken>> Login([FromBody] LoginCommand loginCommand)
    {
        var result = await this.Mediator.Send(loginCommand);
        CookieManager.SetCookie(Response , "refreshToken", result.CookieToken.token , result.CookieToken.expires);
        return Ok(result.JwtToken);
    }
    
    
}
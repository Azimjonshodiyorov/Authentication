using Auth.Application.Commands.Login;
using Auth.Application.Commands.Logout;
using Auth.Application.Commands.Refresh;
using Auth.Application.Commands.Register;
using Auth.Application.Models;
using Auth.WebAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers;
[Authorize]
[Route("api/auth")]
public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) 
        : base(mediator)
    {
    }

    
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Guid) , StatusCodes.Status201Created)]
    public async Task<ActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(result.ToString(), result);
    }


    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(JwtToken) , StatusCodes.Status201Created)]
    public async Task<ActionResult<JwtToken>> Login([FromBody] LoginCommand loginCommand)
    {
        var result = await this.Mediator.Send(loginCommand);
        CookieManager.SetCookie(Response , "refreshToken", result.CookieToken.token , result.CookieToken.expires);
        return Ok(result.JwtToken);
    }

    [HttpPost("refresh")]
    [ProducesResponseType(typeof(JwtToken) , StatusCodes.Status201Created)]
    public async Task<ActionResult<JwtToken>> RefreshToken([FromBody]RefreshCommand refreshCommand)
    {
        var userRefreshToken = Request.Cookies["refreshToken"];
        if (userRefreshToken is null)
            return BadRequest();

        var result = await Mediator.Send(refreshCommand);
        CookieManager.SetCookie(Response , "refreshToken" , result.CookieToken.token , result.CookieToken.expires);
        return Ok(result.JwtToken);
    }


    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Logout()
    {
        var userRefreshToken = Request.Cookies["refreshToken"];

        if (userRefreshToken is null)
            return BadRequest();

        await Mediator.Send(new LogoutCommand(userRefreshToken));
        CookieManager.RemoveCookie(Response , "refreshToken");
        return Ok();
    }
    
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers;

[Authorize]
public class FileController : BaseController
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }

    public FileController(IMediator mediator) : base(mediator)
    {
    }
}
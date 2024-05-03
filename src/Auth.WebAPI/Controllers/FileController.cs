using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers;

[Authorize]

[Route("api/[controller]")]
public class FileController : ControllerBase
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }

    public FileController(IMediator mediator) : base()
    {
    }
}
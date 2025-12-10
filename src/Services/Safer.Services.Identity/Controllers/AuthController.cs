using MediatR;
using Microsoft.AspNetCore.Mvc;
using Safer.Services.Identity.Application.Features.Auth.Commands.RegisterUser;

namespace Safer.Services.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { UserId = userId });
    }
}
using MediatR;

namespace Safer.Services.Identity.Application.Features.Auth.Commands.Login;

// IRequest<string> means this command returns a string (the new User ID)
public record LoginCommand(string Email, string Password) : IRequest<string>;

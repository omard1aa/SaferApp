using MediatR;

namespace Safer.Services.Identity.Application.Features.Auth.Commands.RegisterUser;

// IRequest<string> means this command returns a string (the new User ID)
public record RegisterUserCommand(string Email, string Password, string FirstName, string LastName) : IRequest<string>;

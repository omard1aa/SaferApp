using MediatR;
using Microsoft.AspNetCore.Identity;
using Safer.Services.Identity.Domain.Models;
using Safer.Services.Identity.Domain.Exceptions;

namespace Safer.Services.Identity.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly UserManager<User> _userManager;

    public RegisterUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Create the User entity (using our DDD factory)
        var user = User.Create(request.Email, request.FirstName, request.LastName);

        // 2. Use UserManager to create it in DB with password hashing
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            // Simple error handling for now
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new IdentityValidationException($"Registration failed: {errors}");
        }

        return user.Id;
    }
}
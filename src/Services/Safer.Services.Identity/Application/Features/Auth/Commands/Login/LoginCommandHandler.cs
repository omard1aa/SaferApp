using MediatR;
using Microsoft.AspNetCore.Identity;
using Safer.Services.Identity.Domain.Models;
using Safer.Services.Identity.Domain.Exceptions;
using Safer.Services.Identity.Application.Common.Interfaces;

namespace Safer.Services.Identity.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler: IRequestHandler<LoginCommand, string>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginCommandHandler(UserManager<User> userManager, ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new IdentityValidationException("User not found");
        }
        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            throw new IdentityValidationException("Invalid password");
        }

        return _tokenGenerator.GenerateToken(user);
    }
}
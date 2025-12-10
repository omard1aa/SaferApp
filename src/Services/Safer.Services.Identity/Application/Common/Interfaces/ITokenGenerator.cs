using Safer.Services.Identity.Domain.Models;

namespace Safer.Services.Identity.Application.Common.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
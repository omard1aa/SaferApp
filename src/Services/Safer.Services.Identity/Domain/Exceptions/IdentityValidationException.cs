namespace Safer.Services.Identity.Domain.Exceptions;

public class IdentityValidationException : Exception
{
    public IdentityValidationException(string message) : base(message) { }
}
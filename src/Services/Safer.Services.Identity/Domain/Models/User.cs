using Microsoft.AspNetCore.Identity;

namespace Safer.Services.Identity.Domain.Models;

// Mentorship Note:
// We inherit from IdentityUser to leverage ASP.NET Core Identity's built-in security features (hashing, tokens, etc.)
// However, we treat it as a DDD Entity by keeping business logic inside.
public class User : IdentityUser
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    // Private constructor for EF Core
    private User() { }

    // Factory method to enforce valid creation
    public static User Create(string email, string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

        return new User
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            CreatedAt = DateTime.UtcNow,
            SecurityStamp = Guid.NewGuid().ToString() // Important for security validation
        };
    }

    public void UpdateProfile(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public void RecordLogin()
    {
        LastLoginAt = DateTime.UtcNow;
    }
}

using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public sealed class User : IdentityUser
{
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    public string? Password { get; set; }

    public static ICollection<Message>? Messages { get; set; }
}
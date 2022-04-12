using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public sealed class MessageDbContext : IdentityDbContext
{
    public DbSet<Message>? Messages { get; set; }
    
    public MessageDbContext(DbContextOptions<MessageDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Hubs;

public class ChatHub : Hub
{

    private readonly IServiceProvider _serviceProvider;

    public ChatHub(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    [Authorize]
    public async Task SendMessage(string theme, string message, string achiever)
    {
        var userName = Context.User!.Identity!.Name;
        var messageTime = DateTime.UtcNow.AddHours(3).ToString("t");
        
        var newMessage = new Message(achiever, theme, message, userName, messageTime);

        using var scope = _serviceProvider.CreateScope();
        int id;
            
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var messageContext = scope.ServiceProvider.GetRequiredService<MessageDbContext>();

        var reciever = dbContext.Users.FirstOrDefault(u => u.Email == achiever)!;

        if (reciever == null)
        {
            await Clients.User(Context.UserIdentifier!).SendAsync("ErrorMessage", achiever);
        }
        else
        {
            messageContext.Messages!.Add(newMessage);
            await messageContext.SaveChangesAsync();

            var savedMessage = messageContext.Messages.FirstOrDefault(m => m.Text == message);
            id = savedMessage!.Id;
            await Clients.User(achiever).SendAsync("ReceiveMessage", userName, theme, message, messageTime, id);
        }
    }


}
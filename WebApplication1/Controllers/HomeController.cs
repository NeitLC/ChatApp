using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MessageDbContext _messageDbContext;

    public HomeController(ApplicationDbContext context, MessageDbContext messageDbContext)
    {
        _applicationDbContext = context;
        _messageDbContext = messageDbContext;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        var user = _applicationDbContext.Users.FirstOrDefault(user => user.UserName == User.Identity!.Name);

        return View(user);
    }
    
    [Authorize]
    public IActionResult Messagebox()
    {
        var user = _applicationDbContext.Users.FirstOrDefault(user => user.UserName == User.Identity!.Name);

        return View(user);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Messages()
    {
        ICollection<Message> messages = new List<Message>();
        var allMessages = _messageDbContext.Messages;
        
        foreach (var message in allMessages)
        {
            if(message.Achiever == User.Identity.Name)
                messages.Add(message);
        }
        
        return View(messages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
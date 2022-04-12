using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public sealed class Message
{
    public int Id { get; set; }
    public string? Achiever { get; set; }
    [Required]
    public string? Topic { get; set; }
    [Required]
    public string? Text { get; set; }
    public string? Sender { get; set; }
    public string? Time { get; set; }

    public Message(string achiever, string topic, string text, string? sender, string time)
    {
        Achiever = achiever;
        Topic = topic;
        Text = text;
        Sender = sender;
        Time = time;
    }
}
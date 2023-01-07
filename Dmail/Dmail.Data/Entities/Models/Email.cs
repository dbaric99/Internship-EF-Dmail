namespace Dmail.Data.Entities.Models;

public class Email : MailType
{
    public string Content { get; set; }

    public int ReceiverId { get; set; }
    public Account Receiver { get; set; } = null!;
    
    public Email(string title, DateTime dateAndTime, string content) : base(title, dateAndTime)
    {
        Content = content;
    }
}
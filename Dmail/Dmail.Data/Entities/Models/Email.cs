namespace Dmail.Data.Entities.Models;

public class Email : MailType
{
    public string Content { get; set; }

    public int ReceiverId { get; set; }
    public Account Receiver { get; set; }
    
    public Email(Account sender, string title, DateTime dateAndTime, string content, Account receiver) : base(sender, title, dateAndTime)
    {
        Content = content;
        Receiver = receiver;
        ReceiverId = receiver.Id;
    }
}
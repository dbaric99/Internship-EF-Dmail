namespace Dmail.Data.Entities.Models;

public abstract class MailType
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DateAndTime { get; set; }
    public bool IsRead { get; set; }
    
    public int SenderId { get; set; }
    public Account Sender { get; set; }
    
    public MailType(Account sender, string title, DateTime dateAndTime)
    {
        Sender = sender;
        SenderId = sender.Id;
        Title = title;
        DateAndTime = dateAndTime;
    }
}
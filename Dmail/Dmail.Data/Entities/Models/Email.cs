namespace Dmail.Data.Entities.Models;

public class Email
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateAndTime { get; set; }
    
    public Account Sender { get; set; }
    public Account Receiver { get; set; }
    
    public Email()
    {
            
    }
}
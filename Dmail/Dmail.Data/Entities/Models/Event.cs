namespace Dmail.Data.Entities.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DateAndTime { get; set; }
    
    public Account Sender { get; set; }
    public ICollection<Account> Attendees { get; set; } = new List<Account>();

    public Event()
    {
            
    }
}
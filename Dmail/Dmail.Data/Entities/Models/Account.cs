namespace Dmail.Data.Entities.Models;

public class Account : User
{
    public string Email { get; set; }
    public bool Deactivated { get; set; }
    public bool Spam { get; set; }
    
    public ICollection<Email> SentEmails { get; set; } = new List<Email>();
    public ICollection<Email> ReceivedEmails { get; set; } = new List<Email>();
    public ICollection<Event> SentEvents { get; set; } = new List<Event>();
    public ICollection<Attendance> AttendedEvents { get; set; } = new List<Attendance>();

    public Account(string email, string password) : base()
    {
        Email = email;
        Password = password;
    }
}
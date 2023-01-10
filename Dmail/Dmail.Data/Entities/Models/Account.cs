namespace Dmail.Data.Entities.Models;

public class Account : User
{
    public string Email { get; set; }
    public bool Deactivated { get; set; }

    public ICollection<Email> SentEmails { get; set; } = new List<Email>();
    public ICollection<Email> ReceivedEmails { get; set; } = new List<Email>();
    public ICollection<Event> SentEvents { get; set; } = new List<Event>();
    public ICollection<Attendance> AttendedEvents { get; set; } = new List<Attendance>();

    public ICollection<SpamAccount> SpamAccounts { get; set; } = new List<SpamAccount>();

    public Account(string email, string password)
    {
        Email = email;
        Password = password;
        Deactivated = false;
    }

    public Account() : base()
    {
        Deactivated = false;
    }
}
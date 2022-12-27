namespace Dmail.Data.Entities.Models;

public class Account : User
{
    public string Email { get; set; }
    public bool Deactivated { get; set; } = false;
    public bool Spam { get; set; } = false;

    public ICollection<Email> AllEmail { get; set; } = new List<Email>();
    public ICollection<Event> Events { get; set; } = new List<Event>();

    public Account() : base()
    {
            
    }
}
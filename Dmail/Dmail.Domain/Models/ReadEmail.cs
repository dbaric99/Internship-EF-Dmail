using Dmail.Data.Entities.Models;

namespace Dmail.Domain.Models;

public class ReadEmail
{
    public Email? ReceivedEmail { get; set; }
    public Event? ReceivedEvent { get; set; }
    public bool IsRead { get; set; }
    public ReadEmail(Email receivedEmail, Event receivedEvent, bool isRead = false)
    {
        ReceivedEmail = receivedEmail;
        ReceivedEvent = receivedEvent;
        IsRead = isRead;
    }
}
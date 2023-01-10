using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class SpamAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Spam";

    public SpamAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }

    public void Open()
    {
        
    }
}
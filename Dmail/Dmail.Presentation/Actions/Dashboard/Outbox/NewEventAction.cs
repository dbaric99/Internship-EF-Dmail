using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Outbox;

public class NewEventAction : IAction
{
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Send new event";

    public NewEventAction(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public void Open()
    {
        
    }
}
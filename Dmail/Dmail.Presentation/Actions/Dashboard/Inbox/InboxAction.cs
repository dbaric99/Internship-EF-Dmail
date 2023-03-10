using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Extensions;
using Dmail.Presentation.Factories;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class InboxAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Inbox(received)";

    public InboxAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }

    public void Open()
    {
        var inboxFactory = InboxActionsFactory.CreateActions();
        inboxFactory.PrintActionsAndOpen();
    }
}
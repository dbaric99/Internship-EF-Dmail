using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class MailBySenderAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Search mail by sender";

    public MailBySenderAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }
    public void Open()
    {
        Console.WriteLine("Search from: ");
        var searchToken = Console.ReadLine();

        var selectedEvents = _eventRepository.SearchByAccountAddress(searchToken);
        var selectedEmails = _emailRepository.SearchByAccountAddress(searchToken);
    }
}
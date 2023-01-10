using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class UnReadMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Unread mail";

    public UnReadMailAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }
    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");
        
        List<Email> unreadEmails = null;
        List<Event> unreadEvents = null;
        if (_emailRepository.GetUnReadEmails() is not null)
        {
            unreadEmails = _emailRepository.GetUnReadEmails().Where(e=>e.Sender == authUser || e.Receiver == authUser).ToList();
        }

        if (_eventRepository.GetUnReadEvents() is not null)
        {
            unreadEvents = _eventRepository.GetUnReadEvents().Where(e=>e.Sender == authUser || _eventRepository.CheckIfUserIsAttendingEvent(authUser.Id, e)).ToList();   
        }

        WritingHelper.HandleReadEmails(authUser, unreadEmails, _emailRepository);
        WritingHelper.HandleReadEvents(authUser, unreadEvents, _eventRepository);
    }
}
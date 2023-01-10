using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class ReadMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Read mail";

    public ReadMailAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }
    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        List<Email> readEmails = null;
        List<Event> readEvents = null;
        if (_emailRepository.GetReadEmails() is not null)
        {
            readEmails = _emailRepository.GetReadEmails().Where(e=>e.Sender == authUser || e.Receiver == authUser).ToList();
        }

        if (_eventRepository.GetReadEvents() is not null)
        {
            readEvents = _eventRepository.GetReadEvents().Where(e=>e.Sender == authUser || _eventRepository.CheckIfUserIsAttendingEvent(authUser.Id, e)).ToList();   
        }

        WritingHelper.HandleReadEmails(authUser, readEmails, _emailRepository);
        WritingHelper.HandleReadEvents(authUser, readEvents, _eventRepository);
    }

   
}
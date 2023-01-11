using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class DeleteMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private MailType _mail;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete";

    public DeleteMailAction(EmailRepository emailRepository, EventRepository eventRepository, MailType mail)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
        _mail = mail;
    }

    public void Open()
    {
        if (_mail is Email)
            _emailRepository.Delete(_mail.Id);
        else if (_mail is Event)
            _eventRepository.Delete(_mail.Id);
    }
}
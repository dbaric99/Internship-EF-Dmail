using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Outbox;

public class OutboxAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Outbox(sent)";

    public OutboxAction(EmailRepository emailRepository, EventRepository eventRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
    }
    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        var eventsSentByUser = _eventRepository.SearchBySender(authUser.Id);
        var emailsSentByUser = _emailRepository.SearchBySender(authUser.Id);
        
        if (emailsSentByUser.Count == 0)
            Console.WriteLine("----- No Emails -----");
        else
        {
            WritingHelper.PrintMailAndSelect(emailsSentByUser, false);
        }

        if (eventsSentByUser.Count == 0)
            Console.WriteLine("----- No Events -----");
        else
        {
            WritingHelper.PrintEventAndSelect(eventsSentByUser, false);
        }
    }
}
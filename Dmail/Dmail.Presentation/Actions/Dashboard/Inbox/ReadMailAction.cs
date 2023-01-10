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
        var readEmails = _emailRepository.GetReadEmails();
        if (readEmails.Count == 0)
        {
            Console.WriteLine("----- Empty -----");
            return;
        }
        Console.WriteLine("----- Read Emails -----");
        
        var navigatedEmail = PrintMailAndSelect(readEmails.OrderByDescending(e=>e.DateAndTime).ToList());

        if (navigatedEmail is not null)
        {
            
        }
    }

    public Email PrintMailAndSelect(List<Email> emails)
    {
        for (int i = 1; i < emails.Count; i++)
        {
            var current = emails[i-1];
            Console.WriteLine($"{i} - {current.Title} - {current.Sender.Email}");
        }

        var num = InputHelper.NumberInput("Which email do you wish to open", 1, emails.Count);

        return num == 0 ? null : emails[num - 1];
    }
}
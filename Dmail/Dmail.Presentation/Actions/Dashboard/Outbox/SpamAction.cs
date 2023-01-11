using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class SpamAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private readonly SpamAccountRepository _spamAccountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Spam";

    public SpamAction(EmailRepository emailRepository, EventRepository eventRepository, SpamAccountRepository spamAccountRepository)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
        _spamAccountRepository = spamAccountRepository;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        var spamMail = _spamAccountRepository.GetSpamMail(authUser.Id);

        if (spamMail.Item1 is null)
            Console.WriteLine("----- No Spam Mail -----");
        else
        {
            WritingHelper.PrintMailAndSelect(spamMail.Item1, false);
        }
        
        if(spamMail.Item2 is null)
            Console.WriteLine("----- No Spam Events -----");
        else
        {
            WritingHelper.PrintEventAndSelect(spamMail.Item2, false);
        }
    }
}
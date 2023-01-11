using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class MarkSpamAction : IAction
{
    private readonly SpamAccountRepository _accountRepository;
    private MailType _mail;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Mark as spam";

    public MarkSpamAction(SpamAccountRepository accountRepository, MailType mail)
    {
        _accountRepository = accountRepository;
        _mail = mail;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");
        
        var senderId = _mail.SenderId;
        var res = _accountRepository.Add(senderId, authUser.Id);

        if (res == Response.Success)
        {
            MessageHelper.PrintSuccessMessage("Account marked as spam!");
        }
    }
}
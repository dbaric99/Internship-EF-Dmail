using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Outbox;

public class NewMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly AccountRepository _accountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Compose new mail";

    public NewMailAction(EmailRepository emailRepository, AccountRepository accountRepository)
    {
        _emailRepository = emailRepository;
        _accountRepository = accountRepository;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");
        
        Console.Write("\nInput receiving email address or addresses (separated by comma): ");
        var receiversString = Console.ReadLine().Trim();
        var receivers = InputHelper.EmailReceiversInput(receiversString, _accountRepository);

        if (receivers.Count == 0)
        {
            MessageHelper.PrintErrorMessage("No valid email address!");
            return;
        }

        Console.Write("\nEmail title: ");
        var title = Console.ReadLine();

        if (title is null)
        {
            MessageHelper.PrintErrorMessage("Email title cannot be empty!");
            return;
        }
        
        Console.Write("\nEmail content: ");
        var content = Console.ReadLine().TrimEnd();

        foreach (var rec in receivers)
        {
            var recId = _accountRepository.FindByEmail(rec).Id;
            _emailRepository.Add(new Email
            {
                Title = title,
                DateAndTime = DateTime.Now,
                IsRead = false,
                SenderId = authUser.Id,
                Content = content,
                ReceiverId = recId,
            });
        }
    }
}
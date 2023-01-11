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
        
        Console.Write("\nInput receiving email address or addresses: ");
        var receiversString = Console.ReadLine().Trim();
        var receivers = EmailReceivers(receiversString);

        if (receivers.Count == 0)
        {
            MessageHelper.PrintErrorMessage("No valid email address!");
            return;
        }
        foreach (var rec in receivers)
        {
            if (_accountRepository.FindByEmail(rec) is null)
            {
                MessageHelper.PrintErrorMessage($"Email {rec} is not valid!");
                receivers.Remove(rec);
            }
        }

        if (receivers.Count == 0) return;
        
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

    public List<string> EmailReceivers(string receivers)
    {
        var receiversList = new List<string>();

        if (!receivers.Contains(','))
        {
            if (ValidationHelper.EmailValidation(receivers))
            {
                receiversList.Add(receivers);
            }
        }
        else if (receivers.Contains(','))
        {
            foreach (var receiver in receivers.Split(','))
            {
                if(ValidationHelper.EmailValidation(receiver))
                    receiversList.Add(receiver);
            }
        }

        return receiversList;
    }
}
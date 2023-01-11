using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class RespondToMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly EventRepository _eventRepository;
    private MailType _mail;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Respond";

    public RespondToMailAction(EmailRepository emailRepository, EventRepository eventRepository, MailType mail)
    {
        _emailRepository = emailRepository;
        _eventRepository = eventRepository;
        _mail = mail;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        if (_mail is Email)
        {
            Console.Write("\nEmail content: ");
            var content = Console.ReadLine().TrimEnd();
            _emailRepository.Add(new Email
            {
                Title = "Re: " + _mail.Title,
                DateAndTime = DateTime.Now,
                IsRead = false,
                SenderId = authUser.Id,
                Content = content,
                ReceiverId = _mail.SenderId,
            });
            return;
        }
        if (_mail.SenderId != authUser.Id)
        {
            Console.Write("\nConfirm participation (y/n): ");
            var isComing = InputHelper.IsInputConforming(Console.ReadLine());
            _attendanceRepo
        }
    }
}
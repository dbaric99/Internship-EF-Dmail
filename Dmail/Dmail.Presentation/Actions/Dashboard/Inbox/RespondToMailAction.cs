using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Inbox;

public class RespondToMailAction : IAction
{
    private readonly EmailRepository _emailRepository;
    private readonly AttendanceRepository _attendanceRepository;
    private MailType _mail;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Respond";

    public RespondToMailAction(EmailRepository emailRepository, AttendanceRepository attendanceRepository, MailType mail)
    {
        _emailRepository = emailRepository;
        _attendanceRepository = attendanceRepository;
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
                DateAndTime = DateTime.UtcNow,
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
            _attendanceRepository.SetAttendance(isComing, _mail as Event, authUser);
            _emailRepository.Add(new Email
            {
                Title = "Re: Event attendance: " + _mail.Title,
                DateAndTime = DateTime.UtcNow,
                IsRead = false,
                SenderId = authUser.Id,
                Content = isComing ? "Coming" : "Not coming",
                ReceiverId = _mail.SenderId
            });
        }
    }
}
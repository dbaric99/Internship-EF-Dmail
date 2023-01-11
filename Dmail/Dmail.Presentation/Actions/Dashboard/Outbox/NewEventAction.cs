using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Outbox;

public class NewEventAction : IAction
{
    private readonly EventRepository _eventRepository;
    private readonly AccountRepository _accountRepository;
    private readonly AttendanceRepository _attendanceRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Send new event";

    public NewEventAction(EventRepository eventRepository, AccountRepository accountRepository, AttendanceRepository attendanceRepository)
    {
        _eventRepository = eventRepository;
        _accountRepository = accountRepository;
        _attendanceRepository = attendanceRepository;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        Console.Write("\nInput event attendees: ");
        var attendeesString = Console.ReadLine().Trim();
        var attendeesList = InputHelper.EmailReceiversInput(attendeesString, _accountRepository);
        if (attendeesList.Count == 0)
        {
            MessageHelper.PrintErrorMessage("No valid receiving email address!");
            return;
        }
        
        Console.Write("\nInput event name: ");
        var title = Console.ReadLine().TrimEnd();
        if (title is null)
        {
            MessageHelper.PrintErrorMessage("Title cannot be null!");
            return;
        }
        
        Console.Write("\nInput event date and time in format MM/dd/yyyy HH:mm:ss : ");
        var dateParseSuccess = DateTime.TryParse(Console.ReadLine(), out var dateAndTimeOfEvent);

        if (!dateParseSuccess)
        {
            MessageHelper.PrintErrorMessage("Wrong date format!");
            return;
        }

        var newEvent = new Event
        {
            Title = title,
            DateAndTime = dateAndTimeOfEvent,
            IsRead = false,
            SenderId = authUser.Id
        };
        
        _eventRepository.Add(newEvent);

        foreach (var attendee in attendeesList)
        {
            Console.Write($"\nDid user {attendee} confirm they are coming (y/n): ");
            var isAttending = InputHelper.IsInputConforming(Console.ReadLine());
            
            _attendanceRepository.Add(new Attendance
            {
                IsAttending = isAttending,
                AttendeeId = _accountRepository.FindByEmail(attendee).Id,
                EventId = _eventRepository.GetEventId(newEvent),
            });
        }
    }
}
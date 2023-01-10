using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;

namespace Dmail.Presentation.Helpers;

public static class WritingHelper
{
    #region ReadEvents

    public static void HandleReadEvents(Account authUser, List<Event> allEvents, EventRepository eventRepository)
    {
        if (allEvents.Count == 0)
        {
            Console.WriteLine("----- No Events -----");
            return;
        }
        Console.WriteLine("----- Events -----");
        
        var navigatedEvent = PrintEventAndSelect(allEvents.OrderByDescending(e=>e.DateAndTime).ToList(), true);

        if (navigatedEvent is not null)
        {
            OpenEvent(navigatedEvent, eventRepository);
        }
    }

    public static Event PrintEventAndSelect(List<Event> userEvents, bool shouldSelect)
    {
        for (int i = 1; i < userEvents.Count; i++)
        {
            var current = userEvents[i-1];
            Console.WriteLine($"{i} - {current.Title} - {current.Sender.Email}");
        }

        if (!shouldSelect) return null;
        
        var num = InputHelper.NumberInput("Which event do you wish to open", 1, userEvents.Count);

        return num == 0 ? null : userEvents[num - 1];
    }

    private static void OpenEvent(Event selectedEvent, EventRepository eventRepository)
    {
        Console.WriteLine(new String('-', 25));

        var attendance = selectedEvent.EventAttendance.Aggregate("", (current, att) => current + $"| {att.Attendee.Email}: {att.IsAttending} |");

        Console.WriteLine(
            $"{selectedEvent.Title}\n" + 
            $"{selectedEvent.DateAndTime}\n" + 
            $"{selectedEvent.Sender.Email}\n" + 
            $"{attendance}\n"
        );
        
        eventRepository.SetRead(selectedEvent.Id);
        
        Console.WriteLine(new String('-', 25));
    }

    #endregion

    #region ReadEmails
    public static void HandleReadEmails(Account authUser, List<Email> allEmails, EmailRepository emailRepository)
    {
        if (allEmails.Count == 0)
        {
            Console.WriteLine("----- No Emails -----");
            return;
        }
        Console.WriteLine("----- Emails -----");
        
        var navigatedEmail = PrintMailAndSelect(allEmails.OrderByDescending(e=>e.DateAndTime).ToList(), true);

        if (navigatedEmail is not null)
        {
            OpenMail(navigatedEmail, emailRepository);
        }
    }

    public static Email PrintMailAndSelect(List<Email> emails, bool shouldSelect)
    {
        for (int i = 1; i < emails.Count; i++)
        {
            var current = emails[i-1];
            Console.WriteLine($"{i} - {current.Title} - {current.Sender.Email}");
        }

        if (!shouldSelect) return null;
        
        var num = InputHelper.NumberInput("Which email do you wish to open", 1, emails.Count);

        return num == 0 ? null : emails[num - 1];
    }

    private static void OpenMail(Email email, EmailRepository emailRepository)
    {
        Console.WriteLine(new String('-', 25));
        
        Console.WriteLine(
            $"{email.Title}\n" + 
            $"{email.DateAndTime}\n" + 
            $"{email.Sender.Email}\n" + 
            $"{email.Content}\n"
            );
        
        emailRepository.SetRead(email.Id);
        
        Console.WriteLine(new String('-', 25));
    }
    #endregion
}
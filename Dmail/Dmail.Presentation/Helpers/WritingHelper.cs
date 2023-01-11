using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Extensions;
using Dmail.Presentation.Factories;

namespace Dmail.Presentation.Helpers;

public static class WritingHelper
{
    #region ReadEvents

    public static Event HandleReadEvents(Account authUser, List<Event> allEvents, EventRepository eventRepository, bool shouldSelect)
    {
        if (allEvents.Count == 0)
        {
            Console.WriteLine("----- No Events -----");
            return null;
        }
        Console.WriteLine("----- Events -----");
        
        var navigatedEvent = PrintEventAndSelect(allEvents.OrderByDescending(e=>e.DateAndTime).ToList(), shouldSelect);

        if (navigatedEvent is not null)
        {
            OpenEvent(navigatedEvent, eventRepository);
        }

        return navigatedEvent;
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
        
        var inboxActionsFactory = InboxMiniActionsFactory.CreateActions(selectedEvent);
        inboxActionsFactory.PrintActionsAndOpen();
    }

    #endregion

    #region ReadEmails
    public static Email HandleReadEmails(Account authUser, List<Email> allEmails, EmailRepository emailRepository, bool shouldSelect)
    {
        if (allEmails.Count == 0)
        {
            Console.WriteLine("----- No Emails -----");
            return null;
        }
        Console.WriteLine("----- Emails -----");
        
        var navigatedEmail = PrintMailAndSelect(allEmails.OrderByDescending(e=>e.DateAndTime).ToList(), shouldSelect);

        if (navigatedEmail is not null)
        {
            OpenMail(navigatedEmail, emailRepository);
        }

        return navigatedEmail;
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
        var inboxActionsFactory = InboxMiniActionsFactory.CreateActions(email);
        inboxActionsFactory.PrintActionsAndOpen();
    }
    #endregion
}
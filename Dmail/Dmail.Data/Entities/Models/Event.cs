namespace Dmail.Data.Entities.Models;

public class Event : MailType
{
    public ICollection<Attendance> EventAttendance { get; set; } = new List<Attendance>();

    public Event(Account sender, string title, DateTime dateAndTime, List<Attendance> attendances) : base(sender, title, dateAndTime)
    {
        foreach (var attendee in attendances)
            EventAttendance.Add(attendee);
    }
}
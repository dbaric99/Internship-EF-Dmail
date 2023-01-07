namespace Dmail.Data.Entities.Models;

public class Event : MailType
{
    public ICollection<Attendance> EventAttendance { get; set; } = new List<Attendance>();

    public Event(string title, DateTime dateAndTime) : base(title, dateAndTime)
    {
        
    }
}
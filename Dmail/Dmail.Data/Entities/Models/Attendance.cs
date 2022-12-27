namespace Dmail.Data.Entities.Models;

public class Attendance
{
    public int Id { get; set; }
    public bool IsAttending { get; set; }
    
    public int AttendeeId { get; set; }
    public Account Attendee { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public Attendance()
    {
        
    }
}
namespace Dmail.Data.Entities.Models;

public class Attendance
{
    public bool IsAttending { get; set; }
    
    public Account Attendee { get; set; }
    public Event Event { get; set; }

    public Attendance()
    {
        
    }
}
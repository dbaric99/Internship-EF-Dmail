using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public class EventRepository : BaseRepository
{
    public EventRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public Response Add(Event newEvent)
    {
        DbContext.Events.Add(newEvent);
        return SaveChanges();
    }

    public Response Delete(int idToDelete)
    {
        var eventToDelete = DbContext.Events.Find(idToDelete);
        if (eventToDelete is null) return Response.NotFound;

        DbContext.Events.Remove(eventToDelete);
        
        return SaveChanges();
    }

    public List<Event> GetReadEvents()
    {
        return DbContext.Events.Where(ev => ev.IsRead == true).ToList();
    }
    
    public List<Event> GetUnReadEvents()
    {
        return DbContext.Events.Where(ev => ev.IsRead == false).ToList();
    }

    public Response SetRead(int eventId)
    {
        var eventToUpdate = DbContext.Events.Find(eventId);
        if (eventToUpdate is null) return Response.NotFound;

        eventToUpdate.IsRead = true;

        return SaveChanges();
    }

    public bool CheckIfUserIsAttendingEvent(int accountId, Event current)
    {
        return current.EventAttendance.Any(attendance => attendance.AttendeeId == accountId);
    }

    public List<Event> SearchByAccountAddress(string search)
    {
        return DbContext.Events.Where(ev => ev.Sender.Email.Contains(search)).ToList();
    }
    
    public List<Event> SearchBySender(int senderId)
    {
        return DbContext.Events.Where(ev => ev.SenderId == senderId).ToList();
    }
    
    public int GetEventId(Event targetEvent)
    {
        foreach (var ev in DbContext.Events)
        {
            if (ev.SenderId == targetEvent.SenderId && ev.Title == targetEvent.Title &&
                ev.DateAndTime == targetEvent.DateAndTime)
            {
                return ev.Id;
            }
        }

        return -1;
    }
    
    public Response MarkUnread(int eventId)
    {
        var eventToUpdate = DbContext.Emails.Find(eventId);
        if (eventToUpdate is null) return Response.NotFound;

        eventToUpdate.IsRead = false;

        return SaveChanges();
    }
}
using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Dmail.Domain.Models;

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
}
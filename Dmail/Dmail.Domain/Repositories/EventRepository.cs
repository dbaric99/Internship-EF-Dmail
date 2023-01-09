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
}
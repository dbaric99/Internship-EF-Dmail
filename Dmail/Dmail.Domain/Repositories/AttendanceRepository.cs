using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public class AttendanceRepository : BaseRepository
{
    public AttendanceRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public Response Add(Attendance newAttendance)
    {
        DbContext.Attendances.Add(newAttendance);
        return SaveChanges();
    }

    public Response Delete(int idToDelete)
    {
        var attendanceToDelete = DbContext.Attendances.Find(idToDelete);
        if (attendanceToDelete is null) return Response.NotFound;

        DbContext.Attendances.Remove(attendanceToDelete);
        
        return SaveChanges();
    }

    public Response Update(Attendance updatedAttendance, int idToUpdate)
    {
        var attendanceToUpdate = DbContext.Attendances.Find(idToUpdate);
        if (attendanceToUpdate is null) return Response.NotFound;

        attendanceToUpdate.IsAttending = updatedAttendance.IsAttending;
        attendanceToUpdate.AttendeeId = updatedAttendance.AttendeeId;
        attendanceToUpdate.Attendee = updatedAttendance.Attendee;
        attendanceToUpdate.EventId = updatedAttendance.EventId;
        attendanceToUpdate.Event = updatedAttendance.Event;
        
        return SaveChanges();
    }

    public Response SetAttendance(bool isAttending, Event attendingEvent, Account authUser)
    {
        var targetAttendance = DbContext.Attendances.FirstOrDefault(a => a.Event == attendingEvent && a.Attendee == authUser);

        if (targetAttendance is null) return Response.NotFound;

        targetAttendance.IsAttending = isAttending;

        return SaveChanges();
    }
}
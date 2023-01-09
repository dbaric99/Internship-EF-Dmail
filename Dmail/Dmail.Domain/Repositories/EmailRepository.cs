using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public class EmailRepository : BaseRepository
{
    public EmailRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public Response Add(Email newEmail)
    {
        DbContext.Emails.Add(newEmail);
        return SaveChanges();
    }

    public Response Delete(int idToDelete)
    {
        var emailToDelete = DbContext.Emails.Find(idToDelete);
        if (emailToDelete is null) return Response.NotFound;

        DbContext.Emails.Remove(emailToDelete);
        
        return SaveChanges();
    }
}
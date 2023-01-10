using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Dmail.Domain.Models;

namespace Dmail.Domain.Repositories;

public class EmailRepository : BaseRepository
{
    private List<ReadEmail> _readEmails = new();
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

    public bool CheckIfRead()
    {
        return true;
    }

    public void SetRead()
    {
        if (_readEmails.Count == 0)
        {
            
        }
    }
}
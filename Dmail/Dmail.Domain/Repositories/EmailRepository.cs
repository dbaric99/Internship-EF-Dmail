using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Dmail.Domain.Models;

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

    public List<Email> GetReadEmails()
    {
        return DbContext.Emails.Where(email => email.IsRead == true).ToList();
    }
    
    public List<Email> GetUnReadEmails()
    {
        return DbContext.Emails.Where(email => email.IsRead == false).ToList();
    }

    public Response SetRead(int emailId)
    {
        var emailToUpdate = DbContext.Emails.Find(emailId);
        if (emailToUpdate is null) return Response.NotFound;

        emailToUpdate.IsRead = true;

        return SaveChanges();
    }
    
    public List<Email> SearchByAccountAddress(string search)
    {
        return DbContext.Emails.Where(e => e.Sender.Email.Contains(search)).ToList();
    }

    public List<Email> SearchBySender(int senderId)
    {
        return DbContext.Emails.Where(email => email.SenderId == senderId).ToList();
    }
}
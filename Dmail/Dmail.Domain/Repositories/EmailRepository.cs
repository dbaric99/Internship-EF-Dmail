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

    public bool CheckIfRead(int emailId)
    {
        return _readEmails.FirstOrDefault(e => e.ReceivedEmail.Id == emailId).IsRead;
    }

    public void SetReadEmailStatus()
    {
        if (_readEmails.Count == 0)
        {
            foreach (var email in DbContext.Emails)
            {
                _readEmails.Add(new ReadEmail(email, null));
            }
        }
    }

    public List<Email> GetReadEmails()
    {
        SetReadEmailStatus();

        return DbContext.Emails.Where(email => _readEmails.First(e => e.ReceivedEmail == email).IsRead).ToList();
    }

    public void SetRead(int emailId)
    {
        SetReadEmailStatus();

        foreach (var email in _readEmails.Where(email => email.ReceivedEmail.Id == emailId))
        {
            email.IsRead = true;
        }
    }
}
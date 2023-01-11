using Dmail.Data.Entities;

namespace Dmail.Domain.Repositories;

public class AdminRepository : BaseRepository
{
    public AdminRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public string GetAdminEncryptedPassword()
    {
        return DbContext.Admins.First().Password;
    }
}
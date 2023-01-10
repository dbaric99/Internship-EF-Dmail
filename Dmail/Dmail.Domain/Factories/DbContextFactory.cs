using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Dmail.Domain.Factories;

public static class DbContextFactory
{
    public static DmailDbContext GetDmailDbContext()
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(ConfigurationManager.ConnectionStrings["DmailApp"].ConnectionString)
            .Options;

        return new DmailDbContext(options);
    }
}
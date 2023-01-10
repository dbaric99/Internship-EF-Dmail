using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Dmail.Domain.Factories;

public static class DbContextFactory
{
    public static DmailDbContext GetDmailDbContext()
    {
        //TODO check
        var configurationManager = new ConfigurationManager();
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(configurationManager.GetConnectionString("DmailApp"))
            .Options;

        return new DmailDbContext(options);
    }
}
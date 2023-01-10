using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using UtilityLibrary;

namespace Dmail.Data.Seed;

public static class DatabaseSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var account1 = new Account()
        {
            Id = 1,
            Email = "budinger@gmail.com",
            Password = PasswordLibrary.EncryptPassword("asdfgh")
        };
        var account2 = new Account()
        {
            Id = 2,
            Email = "notaprguy@gmail.com",
            Password = PasswordLibrary.EncryptPassword("password123")
        };
        var account3 = new Account()
        {
            Id = 3,
            Email = "drhyde@gmail.com",
            Password = PasswordLibrary.EncryptPassword("apples")
        };
        var account4 = new Account()
        {
            Id = 4,
            Email = "mrgreen@gmail.com",
            Password = PasswordLibrary.EncryptPassword("pickles11")
        };
        var account5 = new Account()
        {
            Id = 5,
            Email = "lbaxter@gmail.com",
            Password = PasswordLibrary.EncryptPassword("emailpassword123")
        };
        modelBuilder.Entity<Account>()
            .HasData(new List<Account>
            {
                account1, account2, account3, account4, account5
            });

        modelBuilder.Entity<Admin>()
            .HasData(new List<Admin>
            {
                new()
                {
                    Id = 1,
                    Password = PasswordLibrary.EncryptPassword("admin")
                }
            });

        modelBuilder.Entity<Email>()
            .HasData(new List<Email>
            {
                new()
                {
                    Id = 1,
                    Title = "Very important message",
                    DateAndTime = new DateTime(2023, 1, 5, 0, 0, 0, DateTimeKind.Utc),
                    SenderId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras odio.",
                    ReceiverId = 2
                },
                new()
                {
                    Id = 2,
                    Title = "Hello there",
                    DateAndTime = new DateTime(2022, 12, 15, 0, 0, 0, DateTimeKind.Utc),
                    SenderId = 2,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec.",
                    ReceiverId = 5
                },
                new()
                {
                    Id = 3,
                    Title = "Happy New Years",
                    DateAndTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    SenderId = 3,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mauris.",
                    ReceiverId = 5
                },
                new()
                {
                    Id = 4,
                    Title = "Merry Christmas",
                    DateAndTime = new DateTime(2022, 12, 25, 0, 0, 0, DateTimeKind.Utc),
                    SenderId = 3,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non.",
                    ReceiverId = 5
                }
            });

        var event1 = new Event()
        {
            Id = 1,
            Title = "First event",
            DateAndTime = new DateTime(2023, 10, 15, 0, 0, 0, DateTimeKind.Utc),
            SenderId = 3
        };
        var event2 = new Event()
        {
            Id = 2,
            Title = "Second event",
            DateAndTime = new DateTime(2023, 10, 22, 0, 0, 0, DateTimeKind.Utc),
            SenderId = 5
        };
        var event3 = new Event()
        {
            Id = 3,
            Title = "Third event",
            DateAndTime = new DateTime(2023, 10, 29, 0, 0, 0, DateTimeKind.Utc),
            SenderId = 1
        };

        modelBuilder.Entity<Event>()
            .HasData(new List<Event>
            {
                event1, event2, event3
            });
    }
}
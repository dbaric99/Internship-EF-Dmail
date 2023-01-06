using Dmail.Data.Entities.Models;
using Dmail.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Dmail.Data.Entities;

public class DmailDbContext : DbContext
{
    public DmailDbContext(DbContextOptions options) : base(options)
    {
            
    }

    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Admin> Admins => Set<Admin>();
    
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Email> Emails => Set<Email>();
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>()
            .HasOne(at => at.Attendee)
            .WithMany(a => a.AttendedEvents)
            .HasForeignKey(at => at.AttendeeId);

        modelBuilder.Entity<Attendance>()
            .HasOne(at => at.Event)
            .WithMany(e => e.EventAttendance)
            .HasForeignKey(at => at.EventId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Sender)
            .WithMany(s => s.SentEvents)
            .HasForeignKey(e => e.SenderId);

        modelBuilder.Entity<Email>()
            .HasOne(e => e.Sender)
            .WithMany(s => s.SentEmails)
            .HasForeignKey(e => e.SenderId);

        modelBuilder.Entity<Email>()
            .HasOne(e => e.Receiver)
            .WithMany(r => r.ReceivedEmails)
            .HasForeignKey(e => e.ReceiverId);

        DatabaseSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
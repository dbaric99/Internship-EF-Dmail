// <auto-generated />
using System;
using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dmail.Data.Migrations
{
    [DbContext(typeof(DmailDbContext))]
    partial class DmailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dmail.Data.Entities.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deactivated")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deactivated = false,
                            Email = "budinger@gmail.com",
                            Password = "xzWY009A2Ww="
                        },
                        new
                        {
                            Id = 2,
                            Deactivated = false,
                            Email = "notaprguy@gmail.com",
                            Password = "SQIfWgAAoU0t5k4OOOZzgQ=="
                        },
                        new
                        {
                            Id = 3,
                            Deactivated = false,
                            Email = "drhyde@gmail.com",
                            Password = "zXJXNaQ1Xzw="
                        },
                        new
                        {
                            Id = 4,
                            Deactivated = false,
                            Email = "mrgreen@gmail.com",
                            Password = "JgZjlwiiQ+8qpbg+W78nFA=="
                        },
                        new
                        {
                            Id = 5,
                            Deactivated = false,
                            Email = "lbaxter@gmail.com",
                            Password = "m8g51dfFWYEDXIpqyUuFtj7lqyeEWnis"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Lekf0gCE9x8=",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AttendeeId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAttending")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("EventId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Emails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras odio.",
                            DateAndTime = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            ReceiverId = 2,
                            SenderId = 1,
                            Title = "Very important message"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec.",
                            DateAndTime = new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            ReceiverId = 5,
                            SenderId = 2,
                            Title = "Hello there"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mauris.",
                            DateAndTime = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            ReceiverId = 5,
                            SenderId = 3,
                            Title = "Happy New Years"
                        },
                        new
                        {
                            Id = 4,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non.",
                            DateAndTime = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            ReceiverId = 5,
                            SenderId = 3,
                            Title = "Merry Christmas"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAndTime = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            SenderId = 3,
                            Title = "First event"
                        },
                        new
                        {
                            Id = 2,
                            DateAndTime = new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            SenderId = 5,
                            Title = "Second event"
                        },
                        new
                        {
                            Id = 3,
                            DateAndTime = new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsRead = false,
                            SenderId = 1,
                            Title = "Third event"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.SpamAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("AccountSpamId")
                        .HasColumnType("integer");

                    b.Property<int>("AccountSpamId1")
                        .HasColumnType("integer");

                    b.HasKey("AccountId", "AccountSpamId");

                    b.HasIndex("AccountSpamId");

                    b.HasIndex("AccountSpamId1");

                    b.ToTable("SpamAccounts");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Attendance", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Account", "Attendee")
                        .WithMany("AttendedEvents")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.Event", "Event")
                        .WithMany("EventAttendance")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Email", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Account", "Receiver")
                        .WithMany("ReceivedEmails")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.Account", "Sender")
                        .WithMany("SentEmails")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Event", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Account", "Sender")
                        .WithMany("SentEvents")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.SpamAccount", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Account", "Account")
                        .WithMany("SpamAccounts")
                        .HasForeignKey("AccountSpamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.Account", "AccountSpam")
                        .WithMany()
                        .HasForeignKey("AccountSpamId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("AccountSpam");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Account", b =>
                {
                    b.Navigation("AttendedEvents");

                    b.Navigation("ReceivedEmails");

                    b.Navigation("SentEmails");

                    b.Navigation("SentEvents");

                    b.Navigation("SpamAccounts");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Event", b =>
                {
                    b.Navigation("EventAttendance");
                });
#pragma warning restore 612, 618
        }
    }
}

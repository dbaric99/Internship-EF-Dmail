using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dmail.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spam",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Deactivated", "Email", "Password" },
                values: new object[,]
                {
                    { 1, false, "budinger@gmail.com", "xzWY009A2Ww=" },
                    { 2, false, "notaprguy@gmail.com", "SQIfWgAAoU0t5k4OOOZzgQ==" },
                    { 3, false, "drhyde@gmail.com", "zXJXNaQ1Xzw=" },
                    { 4, false, "mrgreen@gmail.com", "JgZjlwiiQ+8qpbg+W78nFA==" },
                    { 5, false, "lbaxter@gmail.com", "m8g51dfFWYEDXIpqyUuFtj7lqyeEWnis" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "Role" },
                values: new object[] { 1, "Lekf0gCE9x8=", "admin" });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Content", "DateAndTime", "IsRead", "ReceiverId", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras odio.", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, 2, 1, "Very important message" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec.", new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 5, 2, "Hello there" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mauris.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 5, 3, "Happy New Years" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non.", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), false, 5, 3, "Merry Christmas" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateAndTime", "IsRead", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, "First event" },
                    { 2, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), false, 5, "Second event" },
                    { 3, new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, "Third event" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<bool>(
                name: "Spam",
                table: "Accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

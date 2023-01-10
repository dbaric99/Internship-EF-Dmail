using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dmail.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpamEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpamAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    AccountSpamId = table.Column<int>(type: "integer", nullable: false),
                    AccountSpamId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpamAccounts", x => new { x.AccountId, x.AccountSpamId });
                    table.ForeignKey(
                        name: "FK_SpamAccounts_Accounts_AccountSpamId",
                        column: x => x.AccountSpamId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpamAccounts_Accounts_AccountSpamId1",
                        column: x => x.AccountSpamId1,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpamAccounts_AccountSpamId",
                table: "SpamAccounts",
                column: "AccountSpamId");

            migrationBuilder.CreateIndex(
                name: "IX_SpamAccounts_AccountSpamId1",
                table: "SpamAccounts",
                column: "AccountSpamId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpamAccounts");
        }
    }
}

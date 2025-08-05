using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMailEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentMailId",
                table: "Mails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mails_ParentMailId",
                table: "Mails",
                column: "ParentMailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Mails_ParentMailId",
                table: "Mails",
                column: "ParentMailId",
                principalTable: "Mails",
                principalColumn: "MailId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Mails_ParentMailId",
                table: "Mails");

            migrationBuilder.DropIndex(
                name: "IX_Mails_ParentMailId",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "ParentMailId",
                table: "Mails");
        }
    }
}

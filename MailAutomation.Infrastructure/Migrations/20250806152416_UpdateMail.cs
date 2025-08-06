using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemovedFromReceiver",
                table: "Mails");

            migrationBuilder.RenameColumn(
                name: "IsRemovedFromSender",
                table: "Mails",
                newName: "IsRemoved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Mails",
                newName: "IsRemovedFromSender");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemovedFromReceiver",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

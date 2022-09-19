using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffRoadPortal.Migrations
{
    public partial class bugFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventsId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "Users",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EventsId",
                table: "Users",
                newName: "IX_Users_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Users",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EventId",
                table: "Users",
                newName: "IX_Users_EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventsId",
                table: "Users",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}

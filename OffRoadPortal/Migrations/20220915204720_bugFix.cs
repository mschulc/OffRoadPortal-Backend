using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffRoadPortal.Migrations
{
    public partial class bugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.AddColumn<long>(
                name: "EventsId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventsId",
                table: "Users",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventsId",
                table: "Users",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventsId = table.Column<long>(type: "bigint", nullable: false),
                    ParticipantsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.EventsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_ParticipantsId",
                table: "EventUser",
                column: "ParticipantsId");
        }
    }
}

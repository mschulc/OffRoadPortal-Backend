using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffRoadPortal.Migrations
{
    public partial class carupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Engine",
                table: "Cars",
                type: "float",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Engine",
                table: "Cars",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}

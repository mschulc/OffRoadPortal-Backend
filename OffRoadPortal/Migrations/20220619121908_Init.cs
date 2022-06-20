/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: 20220619121908_Init.cs                            //
/////////////////////////////////////////////////////////////

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffRoadPortal.Migrations;

public partial class Init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Announcements",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                SellerId = table.Column<long>(type: "bigint", nullable: false),
                SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Price = table.Column<double>(type: "float", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Category = table.Column<int>(type: "int", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Visible = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Announcements", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Articles",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AuthorId = table.Column<long>(type: "bigint", nullable: false),
                Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Articles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Events",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                EventOrganizerId = table.Column<long>(type: "bigint", nullable: false),
                EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                EventOrganizer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                StartEventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                EndEventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Category = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Events", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<int>(type: "int", nullable: false),
                Age = table.Column<int>(type: "int", nullable: false),
                Role = table.Column<int>(type: "int", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Car = table.Column<string>(type: "nvarchar(max)", nullable: true),
                City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                EventId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Events_EventId",
                    column: x => x.EventId,
                    principalTable: "Events",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "ArticleComments",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ArticleId = table.Column<long>(type: "bigint", nullable: false),
                UserId = table.Column<long>(type: "bigint", nullable: true),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ArticleComments", x => x.Id);
                table.ForeignKey(
                    name: "FK_ArticleComments_Articles_ArticleId",
                    column: x => x.ArticleId,
                    principalTable: "Articles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ArticleComments_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "EventComments",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                EventId = table.Column<long>(type: "bigint", nullable: false),
                UserId = table.Column<long>(type: "bigint", nullable: true),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EventComments", x => x.Id);
                table.ForeignKey(
                    name: "FK_EventComments_Events_EventId",
                    column: x => x.EventId,
                    principalTable: "Events",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EventComments_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Image",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AnnouncementId = table.Column<long>(type: "bigint", nullable: true),
                UserId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Image", x => x.Id);
                table.ForeignKey(
                    name: "FK_Image_Announcements_AnnouncementId",
                    column: x => x.AnnouncementId,
                    principalTable: "Announcements",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Image_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_ArticleComments_ArticleId",
            table: "ArticleComments",
            column: "ArticleId");

        migrationBuilder.CreateIndex(
            name: "IX_ArticleComments_UserId",
            table: "ArticleComments",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_EventComments_EventId",
            table: "EventComments",
            column: "EventId");

        migrationBuilder.CreateIndex(
            name: "IX_EventComments_UserId",
            table: "EventComments",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Image_AnnouncementId",
            table: "Image",
            column: "AnnouncementId");

        migrationBuilder.CreateIndex(
            name: "IX_Image_UserId",
            table: "Image",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_EventId",
            table: "Users",
            column: "EventId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ArticleComments");

        migrationBuilder.DropTable(
            name: "EventComments");

        migrationBuilder.DropTable(
            name: "Image");

        migrationBuilder.DropTable(
            name: "Articles");

        migrationBuilder.DropTable(
            name: "Announcements");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Events");
    }
}
